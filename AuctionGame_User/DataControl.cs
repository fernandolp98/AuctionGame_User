using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace AuctionGame_User
{
    public class DataControl
    {
        public Font FontPlaceHolder { get; set; }
        public Font FontRegular { get; set; }
        public Color ColorPlaceHolder { get; set; }
        public Color ColorRegular { get; set; }
        public Color ColorError { get; set; }

        public DataControl (Font placeholder, Font regular, Color colorPlaceHolder, Color colorRegular, Color colorError)
        {
            FontPlaceHolder = placeholder;
            FontRegular = regular;
            ColorPlaceHolder = colorPlaceHolder;
            ColorRegular = colorRegular;
            ColorError = colorError;
        }

        public void placeHolder_Leave(TextBox txb)
        {
            if (txb.Text == "")
            {
                Text(txb, txb.Tag.ToString().Split(',')[0]);
                ForeColor(txb, ColorPlaceHolder);
                txb.Font = FontPlaceHolder;
            }
        }
        public void PlaceHolder_Enter(TextBox txb)
        {
            var text = txb.Tag.ToString().Split(',')[0];
            if (txb.Text ==  text && (txb.ForeColor == ColorPlaceHolder || txb.ForeColor == ColorError) && txb.Font.Equals(FontPlaceHolder))
            {
                Text(txb, "");
                ForeColor(txb, ColorRegular);
                txb.Font = FontRegular;
            }
        }
        public void TxbActivar(TextBox txb)
        {
            ForeColor(txb, Color.Black);
            txb.Font = FontRegular;
            txb.Enabled = true;
        }
        public void TxbBorrar(TextBox txb)
        {
            txb.Text = "";
            placeHolder_Leave(txb);
        }
        public void ForeColor(TextBox txb, Color color)
        {
            txb.ForeColor = color;
        }
        public void ForeColor(Button btn, Color color)
        {
            btn.ForeColor = color;
        }
        public void BackColor(TextBox txb, Color color)
        {
            txb.BackColor = color;
        }
        public void BackColor(Button btn, string color)
        {
            
        }

        internal void Clear(TextBox txb)
        {
            var text = txb.Tag.ToString().Split(',')[0];
            txb.Font = FontPlaceHolder;
            txb.ForeColor = ColorPlaceHolder;
            txb.Text = text;
        }

        public void Text(TextBox txb, string str)
        {
            txb.Text = str;
            txb.Font = FontRegular;
            txb.ForeColor = Color.Black;
        }
        public void Text(MaskedTextBox txb, string str)
        {
            txb.Text = str;
            txb.Font = FontRegular;
            txb.ForeColor = ColorRegular;
        }
        public  void Text(Button btn, string str)
        {
            btn.Text = str;
        }
        public void BtnEnabled(Button btn, string color)
        {
            if(!btn.Enabled)
            {
                btn.Enabled = true;
                BackColor(btn, color);
                btn.Visible = true;
            }
        }
        public void BtnUnabled(Button btn, string color, bool visible)
        {
            if (btn.Enabled)
            {
                btn.Enabled = false;
                BackColor(btn, color);
                btn.Visible = visible;
            }
        }
        public void Invalido(object o)
        {
            if (o.GetType() == typeof(TextBox))
            {
                ((TextBox)o).ForeColor = ColorError;
            }
            if (o.GetType() == typeof(MaskedTextBox))
            {
                ((MaskedTextBox)o).ForeColor = ColorError;
            }
        }

        public bool Validar(TextBox txb)
        {
            var type = ((string)txb.Tag).Split(',')[1]; 
            return Validar(txb, type);
        }
        public bool Validar(TextBox txb, string type)
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
                txb.ForeColor = (error) ? ColorError : ColorRegular;
                return error;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return true;
            }
        }
        public bool Validar(MaskedTextBox mtxb)
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
                mtxb.ForeColor = (error) ? ColorError : ColorRegular;
                return error;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return true;
            }
        }
        public bool Validar(object[] array)
        {
            for (var index = 0; index < array.Length; index++)
            {
                if (array[index] is TextBox)
                {
                    var o = (TextBox)array[index];
                    if (o.ForeColor == ColorPlaceHolder || o.ForeColor == ColorError)
                    {
                        return false;
                    }
                }
                else if(array[index] is MaskedTextBox)
                {
                    var o = (MaskedTextBox)array[index];
                    if (o.ForeColor == ColorPlaceHolder || o.ForeColor == ColorError)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public  string ImageToBase64String(Image imagen)
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
