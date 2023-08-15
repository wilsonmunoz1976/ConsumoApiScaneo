using ConsumoApiScaneo.Estructuras;
using GroupDocs.Conversion.Options.Convert;
using Newtonsoft.Json;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encoder = System.Drawing.Imaging.Encoder;

namespace ConsumoApiScaneo
{
    public partial class FrmMostrarImg : Form
    {
        public FrmMostrarImg()
        {
            InitializeComponent();
        }

        private ImageFormat? GetImageFormat(byte[] byteArray)
        {

            const int INT_SIZE = 4; // We only need to check the first four bytes of the file / byte array.

            var bmp = System.Text.Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = System.Text.Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };                // PNG
            var tiff = new byte[] { 73, 73, 42 };                    // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };                   // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 };            // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 };           // jpeg2 (canon)

            // Copy the first 4 bytes into our buffer 
            var buffer = new byte[INT_SIZE];
            System.Buffer.BlockCopy(byteArray, 0, buffer, 0, INT_SIZE);

            if (bmp.SequenceEqual(buffer.Take(bmp.Length)))
                return ImageFormat.Bmp;

            if (gif.SequenceEqual(buffer.Take(gif.Length)))
                return ImageFormat.Gif;

            if (png.SequenceEqual(buffer.Take(png.Length)))
                return ImageFormat.Png;

            if (tiff.SequenceEqual(buffer.Take(tiff.Length)))
                return ImageFormat.Tiff;

            if (tiff2.SequenceEqual(buffer.Take(tiff2.Length)))
                return ImageFormat.Tiff;

            if (jpeg.SequenceEqual(buffer.Take(jpeg.Length)))
                return ImageFormat.Jpeg;

            if (jpeg2.SequenceEqual(buffer.Take(jpeg2.Length)))
                return ImageFormat.Jpeg;

            return null;
        }

        public Image Base64ToImage(string base64String)
        {
            Cursor.Current = Cursors.WaitCursor;
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            Image image = null;
            string sFilenameOrig = "";
            string sFilenameJPG = "";

            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                if (GetImageFormat(imageBytes) != null)
                {
                    image = Image.FromStream(ms);
                } else
                {
                    sFilenameOrig = Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".webp";
                    SaveBytesToFile(sFilenameOrig, imageBytes);

                    using (GroupDocs.Conversion.Converter converter = new GroupDocs.Conversion.Converter(sFilenameOrig))
                    {
                        var convertOptions = converter.GetPossibleConversions()["jpg"].ConvertOptions;
                        sFilenameJPG = sFilenameOrig.Replace(".webp", ".jpg");
                        converter.Convert(sFilenameJPG, convertOptions);
                    };
                    imageBytes = File.ReadAllBytes(sFilenameJPG);
                    using (MemoryStream msjpg = new MemoryStream(imageBytes, 0, imageBytes.Length))
                    {
                        image = Image.FromStream(msjpg);
                    }
                }
            }
            if (sFilenameJPG != "") { File.Delete(sFilenameJPG); }
            if (sFilenameOrig != "") { File.Delete(sFilenameOrig); }

            Cursor.Current = Cursors.Default;
            return image;

        }

        private void SaveBytesToFile(string filename, byte[] bytesToWrite)
        {
            if (filename != null && filename.Length > 0 && bytesToWrite != null)
            {
                if (!Directory.Exists(Path.GetDirectoryName(filename)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filename));

                FileStream file = File.Create(filename);

                file.Write(bytesToWrite, 0, bytesToWrite.Length);

                file.Close();
            }
        }
        private string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                var ep = new EncoderParameters(1);
                ep.Param[0] = new EncoderParameter(Encoder.Quality, 80);

                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to base 64 string
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private void btnMostrarSala_Click(object sender, EventArgs e)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                string sBodega = cboBodega.SelectedItem.ToString().Split("-")[0].Trim();
                string sEstado = cboEstado.SelectedItem.ToString().Trim();
                string sUsuario = txtUsuario.Text.Trim();

                var webRequest = new HttpRequestMessage(HttpMethod.Post, ConsumoApiScaneo.Properties.Settings.Default.URLWebApi + "/api/CofresUrnas/GetCofresUrnas/" + sBodega + "?estado=" + sEstado + (sUsuario == "" ? "" : "&usuario=" + sUsuario))
                {
                    Headers = { Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Program.Token) }
                };
                CofreUrnaResp? cofreUrnaResp = new CofreUrnaResp();

                var response = client.Send(webRequest);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    var serializer = new JsonSerializer();

                    using (var sr = new StreamReader(ToStream(responseString)))
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {

                        cofreUrnaResp = serializer.Deserialize<CofreUrnaResp?>(jsonTextReader);
                    }

                    if (cofreUrnaResp != null)
                    {
                        DataTable tb1 = new DataTable("tb0");
                        tb1.Columns.Add("codigo");
                        tb1.Columns.Add("mensaje");
                        DataRow dr1 = tb1.NewRow();
                        dr1["codigo"] = cofreUrnaResp.Respuesta.codigo;
                        dr1["mensaje"] = cofreUrnaResp.Respuesta.mensaje;
                        tb1.Rows.Add(dr1);

                        //lstCofresUrnas.DataSource = tb1;
                        lstCofresUrnas.DataSource = null;
                        lstCofresUrnas.Items.Clear();
                        if (cofreUrnaResp.Respuesta.codigo == 0)
                        {
                            if (cofreUrnaResp.Detalle != null)
                            {
                                DataTable tb2 = new DataTable("tb1");
                                tb2.Columns.Add("Codigo");
                                tb2.Columns.Add("Producto");

                                foreach (CofreUrnaDet cofreUrna in cofreUrnaResp.Detalle)
                                {
                                    DataRow dr2 = tb2.NewRow();
                                    dr2["Codigo"] = cofreUrna.Codigo;
                                    dr2["Producto"] = cofreUrna.Producto;
                                    tb2.Rows.Add(dr2);
                                }

                                lstCofresUrnas.DataSource = tb2;
                                lstCofresUrnas.DisplayMember = "Producto";
                                lstCofresUrnas.ValueMember = "Codigo";

                                if (lstCofresUrnas.Items.Count > 0)
                                {
                                    LstCofresUrnas_Click(lstCofresUrnas, new EventArgs());
                                }
                            }
                        }
                    }

                    Console.WriteLine(responseString);
                }
            }

        }

        private void FrmMostrarImg_Load(object sender, EventArgs e)
        {
            cboBodega.Items.Clear();

            cboEstado.Items.Clear();
            cboEstado.Items.Add("0");
            cboEstado.Items.Add("1");
            cboEstado.Items.Add("2");
            cboEstado.Items.Add("3");
            cboEstado.SelectedIndex = 0;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {

                var webRequest = new HttpRequestMessage(HttpMethod.Post, ConsumoApiScaneo.Properties.Settings.Default.URLWebApi + "/api/CofresUrnas/GetBodegas")
                {
                    Headers = { Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Program.Token) }
                };

                var response = client.Send(webRequest);

                Bodega? oBodega = new Bodega();

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    var serializer = new JsonSerializer();

                    using (var sr = new StreamReader(ToStream(responseString)))
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        oBodega = serializer.Deserialize<Bodega?>(jsonTextReader);
                    }

                    if (oBodega != null)
                    {
                        if (oBodega.Respuesta != null)
                        {
                            if (Convert.ToInt16(oBodega.Respuesta.codigo) == 0)
                            {
                                if (oBodega.Detalle != null)
                                {
                                    foreach (BodegaDet oBodegaDet in oBodega.Detalle)
                                    {
                                        cboBodega.Items.Add(oBodegaDet.Codigobodega + " - " + oBodegaDet.Nombrebodega);
                                    }
                                    if (cboBodega.Items.Count > 0) { cboBodega.SelectedIndex = 0; }
                                }
                            }
                        }
                    }
                }


            }
        }
        private Stream ToStream(string str)
        {
            MemoryStream stream = new();
            StreamWriter writer = new(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private void LstCofresUrnas_Click(object sender, EventArgs e)
        {
            ListBox ls = (ListBox)sender;

            if (ls.SelectedValue != null)
            {
                string? sCodigo = ls.SelectedValue.ToString();

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (var client = new HttpClient(clientHandler))
                {

                    var webRequest = new HttpRequestMessage(HttpMethod.Post, ConsumoApiScaneo.Properties.Settings.Default.URLWebApi + "/api/CofresUrnas/GetSolEgreCofreUrna/" + sCodigo)
                    {
                        Headers = { Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Program.Token) }
                    };

                    CofreUrnaResp? cofreUrnaResp = new CofreUrnaResp();

                    var response = client.Send(webRequest);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;

                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;

                        var serializer = new JsonSerializer();

                        using (var sr = new StreamReader(ToStream(responseString)))
                        using (var jsonTextReader = new JsonTextReader(sr))
                        {

                            cofreUrnaResp = serializer.Deserialize<CofreUrnaResp?>(jsonTextReader);
                        }

                        if (cofreUrnaResp != null)
                        {
                            if (cofreUrnaResp.Respuesta.codigo == 0)
                            {
                                if (cofreUrnaResp.Detalle != null)
                                {
                                    foreach (CofreUrnaDet cofreUrna in cofreUrnaResp.Detalle)
                                    {
                                        lblID.Text = cofreUrna.Codigo;
                                        lblBodegaOrigen.Text = cofreUrna.Bodega;
                                        lblNombreFallecido.Text = cofreUrna.Inhumado;
                                        if (!string.IsNullOrEmpty(cofreUrna.FotografiaSala))
                                        {
                                            imgCofre.Image = Base64ToImage(cofreUrna.FotografiaSala);
                                        }
                                        else
                                        {
                                            imgCofre.Image = null;
                                        }
                                    }
                                }
                            }
                        }

                        Console.WriteLine(responseString);
                    }
                }

            }
        }
    }
}
