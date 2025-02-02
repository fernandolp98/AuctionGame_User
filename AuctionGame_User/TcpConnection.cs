﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace AuctionGame_User
{
    public class TcpConnection
    {
        public TcpClient TcpClient { get; private set; }
        public NetworkStream Stream { get; private set; }
        public Thread ReadThread { get; private set; }
        public StreamWriter Writer { get; private set; }

        public delegate void DataCarrier(string data);
        public event DataCarrier OnDataRecieved;

        public delegate void DisconnectNotify();
        public event DisconnectNotify OnDisconnect;

        public delegate void ErrorCarrier(Exception e);
        public event ErrorCarrier OnError;

        public bool Connectar(string direccionIp, int puerto)
        {
            try
            {
                TcpClient = new TcpClient();
                TcpClient.Connect(IPAddress.Parse(direccionIp), puerto);
                Stream = TcpClient.GetStream();
                Writer = new StreamWriter(Stream);
                ReadThread = new Thread(Escuchar);
                ReadThread.Start();
                return true;
            }
            catch (Exception e)
            {
                if (OnError == null) return false;
                OnError(e);
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        }

        private void Escuchar()
        {
            var lector = new StreamReader(Stream);
            var charBuffer = new List<int>();

            do
            {
                try
                {
                    if (lector.EndOfStream)
                        break;
                    var charCode = lector.Read();
                    if (charCode == -1)
                        break;
                    if (charCode != 0)
                    {
                        charBuffer.Add(charCode);
                        continue;
                    }
                    if (OnDataRecieved != null)
                    {
                        var chars = new char[charBuffer.Count];
                        for (int i = 0; i < charBuffer.Count; i++)
                        {
                            chars[i] = Convert.ToChar(charBuffer[i]);
                        }
                        var message = new string(chars);
                        OnDataRecieved(message);
                    }
                    charBuffer.Clear();
                }
                catch (Exception e)
                {
                    OnError?.Invoke(e);
                    break;
                }
            } while (true);

            OnDisconnect?.Invoke();
        }
        private void EscribirMsj(string mensaje)
        {
            try
            {
                Writer.Write(mensaje + "\0");
                Writer.Flush();
            }
            catch (Exception e)
            {
                if (OnError != null)
                    OnError(e);
            }
        }
        public void EnviarPaquete(Package paquete)
        {
            EscribirMsj(paquete);
        }
    }
}
