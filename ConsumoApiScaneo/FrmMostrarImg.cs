using ConsumoApiScaneo.Estructuras;
using Newtonsoft.Json;
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

namespace ConsumoApiScaneo
{
    public partial class FrmMostrarImg : Form
    {
        public FrmMostrarImg()
        {
            InitializeComponent();
        }



        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }


        private string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
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

                var webRequest = new HttpRequestMessage(HttpMethod.Post, ConsumoApiScaneo.Properties.Settings.Default.URLWebApi + "/api/CofresUrnas/GetCofresUrnas/" + sBodega + "?estado=" + sEstado + (sUsuario == "" ? "" : "?usuario=" + sUsuario))
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
                  Headers = { Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer" , Program.Token) }
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
