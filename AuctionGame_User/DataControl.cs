using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace AuctionGame_User
{
    static class DataControl
    {
        static readonly Font FontPlaceHolder = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 1);
        static readonly Font FontDefault = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 1);
        //static readonly Font FontRight = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 1);

        public static void placeHolder_Leave(TextBox txb)
        {
            if (txb.Text == "")
            {
                Text(txb, txb.Tag.ToString().Split(',')[0]);
                ForeColor(txb, Color.Silver);
                txb.Font = FontPlaceHolder;
            }
        }
        public static void PlaceHolder_Enter(TextBox txb)
        {
            if (txb.Text == txb.Tag.ToString().Split(',')[0] && (txb.ForeColor == Color.Silver || txb.ForeColor == Color.Red) && txb.Font.Italic)
            {
                Text(txb, "");
                ForeColor(txb, Color.Black);
                txb.Font = FontDefault;
            }
        }
        public static void TxbActivar(TextBox txb)
        {
            ForeColor(txb, Color.Black);
            txb.Font = FontDefault;
            txb.Enabled = true;
        }
        public static void TxbBorrar(TextBox txb)
        {
            txb.Text = "";
            placeHolder_Leave(txb);
        }
        public static void ForeColor(TextBox txb, Color color)
        {
            txb.ForeColor = color;
        }
        public static void ForeColor(Button btn, Color color)
        {
            btn.ForeColor = color;
        }
        public static void BackColor(TextBox txb, Color color)
        {
            txb.BackColor = color;
        } 
        public static void BackColor(Button btn, string color)
        {
            switch(color)
            {
                case "azul": btn.BackColor = Color.FromArgb(255, 9, 101, 176); break;
                case "rojo": btn.BackColor = Color.FromArgb(255, 223, 47, 59); break;
                case "gris": btn.BackColor = Color.FromArgb(255, 126, 136, 143); break;
            }
        }

        internal static void Clear(TextBox txb)
        {
            var text = txb.Tag.ToString().Split(',')[0];
            txb.Font = FontPlaceHolder;
            txb.ForeColor = Color.Silver;
            txb.Text = text;
        }

        public static void Text(TextBox txb, string str)
        {
            txb.Text = str;
            txb.Font = FontDefault;
            txb.ForeColor = Color.Black;
        }
        public static void Text(MaskedTextBox txb, string str)
        {
            txb.Text = str;
            txb.Font = FontDefault;
            txb.ForeColor = Color.Black;
        }
        public static void Text(Button btn, string str)
        {
            btn.Text = str;
        }
        public static void BtnEnabled(Button btn, string color)
        {
            if(!btn.Enabled)
            {
                btn.Enabled = true;
                BackColor(btn, color);
                btn.Visible = true;
            }
        }
        public static void BtnUnabled(Button btn, string color, bool visible)
        {
            if (btn.Enabled)
            {
                btn.Enabled = false;
                BackColor(btn, color);
                btn.Visible = visible;
            }
        }
        public static void Invalido(object o)
        {
            if (o.GetType() == typeof(TextBox))
            {
                ((TextBox)o).ForeColor = Color.Red;
            }
            if (o.GetType() == typeof(MaskedTextBox))
            {
                ((MaskedTextBox)o).ForeColor = Color.Red;
            }
        }

        public static bool Validar(TextBox txb)
        {
            var type = ((string)txb.Tag).Split(',')[1]; 
            return Validar(txb, type);
        }
        public static bool Validar(TextBox txb, string type)
        {
            try
            {
                type = type.Trim();
                type = type.ToLower();
                var error = true;
                if (!txb.Font.Italic)
                {
                    switch (type)
                    {
                        case "alfanumerico":
                            error = !Regex.IsMatch(txb.Text, @"^\S.*$");

                            break;
                        case "texto":
                            error = !Regex.IsMatch(txb.Text, @"^[a-zA-ZñÑ\s]+$");


                            break;
                        case "numeroentero":
                            error = !Regex.IsMatch(txb.Text, @"^[0-9]+$");
                            break;
                        case "decimal":

                            error = !Regex.IsMatch(txb.Text, @"^(\d*\.)?\d+$");
                            break;

                        case "moneda":
                            error = !Regex.IsMatch(txb.Text, @"^[0-9]+[.]+[0-9]{2}$");
                            if (error)
                            {
                                error = Validar(txb, "decimal");
                                if (!error)
                                {
                                    var numero = decimal.Parse(txb.Text);
                                    numero = Math.Round(numero, 2);
                                    var text = numero.ToString("F");
                                    txb.Text = text;
                                }
                            }

                            break;
                        case "correo":
                            error = !Regex.IsMatch(txb.Text,
                                @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" +
                                @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");

                            break;
                        case "telefono":
                            error = !Regex.IsMatch(txb.Text, @"^[0-9]{10}$");

                            break;

                        default:
                            if (type != "alfanumerico") error = false;
                            break;
                    }

                }
                txb.ForeColor = (error) ? Color.Red : Color.Black;
                return error;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return true;
            }
        }
        public static bool Validar(MaskedTextBox mtxb)
        {
            try
            {
                var error = mtxb.ValidatingType == null || !mtxb.MaskFull;
                if (!error)
                {
                    if ((mtxb.ValidatingType.Name is "DateTime"))
                    {
                        error = !Time.TryParse(mtxb.Text);
                    }
                }
                mtxb.ForeColor = (error) ? Color.Red : Color.Black;
                return error;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return true;
            }
        }
        public static bool Validar(object[] array)
        {
            for (var index = 0; index < array.Length; index++)
            {
                if (array[index] is TextBox)
                {
                    var o = (TextBox)array[index];
                    if (o.ForeColor == Color.Silver || o.ForeColor == Color.Red)
                    {
                        return false;
                    }
                }
                else if(array[index] is MaskedTextBox)
                {
                    var o = (MaskedTextBox)array[index];
                    if (o.ForeColor == Color.Silver || o.ForeColor == Color.Red)
                    {
                        return false;
                    }
                }


            }

            return true;
        }

        public static string ImageToBase64String(Image imagen)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static Image Base64StringToImage(string stringBase64)
        {
            var imageBytes = Convert.FromBase64String(stringBase64);
            using (var ms = new System.IO.MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                return Image.FromStream(ms, true);
            }
        }
    }
}
