using ConsumoApiScaneo.Estructuras;
using Newtonsoft.Json;
using System.Data;
using System.IO;

namespace ConsumoApiScaneo
{
    public partial class FrmListadoBodegas : Form
    {
        public FrmListadoBodegas()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
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

                        dataGridView1.DataSource = tb1;

                        if (cofreUrnaResp.Detalle != null)
                        {
                            DataTable tb2 = new DataTable("tb1");
                            tb2.Columns.Add("Codigo");
                            tb2.Columns.Add("Bodega");
                            tb2.Columns.Add("Producto");
                            tb2.Columns.Add("Inhumado");
                            tb2.Columns.Add("NombreProveedor");

                            foreach (CofreUrnaDet cofreUrna in cofreUrnaResp.Detalle)
                            {
                                DataRow dr2 = tb2.NewRow();
                                dr2["Codigo"] = cofreUrna.Codigo;
                                dr2["Bodega"] = cofreUrna.Bodega;
                                dr2["Producto"] = cofreUrna.Producto;
                                dr2["Inhumado"] = cofreUrna.Inhumado;
                                dr2["NombreProveedor"] = cofreUrna.NombreProveedor;
                                tb2.Rows.Add(dr2);
                            }

                            dataGridView2.DataSource = tb2;
                        }
                    }

                    Console.WriteLine(responseString);
                }
            }
        }

        private Stream ToStream(string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private void Form1_Load(object sender, EventArgs e)
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

                var webRequest = new HttpRequestMessage(HttpMethod.Post, ConsumoApiScaneo.Properties.Settings.Default.URLWebApi + "/api/CofresUrnas/GetBodegas") { };
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
    }
}