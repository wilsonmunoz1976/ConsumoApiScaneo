using ConsumoApiScaneo.Estructuras;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumoApiScaneo
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                string sUsuario = txtUsuario.Text.Trim();
                string sPassword = txtPassword.Text.Trim();

                cmdVerCofresUrnas.Enabled = false;
                var serializer = new JsonSerializer();

                LoginReq oReq = new LoginReq()
                {
                    Usuario = sUsuario,
                    Password = sPassword
                };

                var webRequest = new HttpRequestMessage(HttpMethod.Post, ConsumoApiScaneo.Properties.Settings.Default.URLWebApi + "/api/Login/LoginApp")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(oReq), Encoding.UTF8, "application/json")
                };
                LoginResp? oLoginResp = new LoginResp();

                var response = client.Send(webRequest);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;


                    oLoginResp = JsonConvert.DeserializeObject<LoginResp?>(responseString);


                    if (oLoginResp != null)
                    {
                        DataTable tb1 = new DataTable("tb0");
                        tb1.Columns.Add("codigo");
                        tb1.Columns.Add("mensaje");
                        DataRow dr1 = tb1.NewRow();
                        dr1["codigo"] = oLoginResp.Respuesta.codigo;
                        dr1["mensaje"] = oLoginResp.Respuesta.mensaje;
                        tb1.Rows.Add(dr1);
                        dataGridView1.DataSource = tb1;

                        if (oLoginResp.Parametro != null)
                        {
                            DataTable tb2 = new DataTable("tb1");
                            tb2.Columns.Add("NombreParametro");
                            tb2.Columns.Add("ValorParametro");
                            tb2.Columns.Add("DescripcionParametro");

                            foreach (LoginParam oLoginParam in oLoginResp.Parametro)
                            {
                                DataRow dr2 = tb2.NewRow();
                                dr2["NombreParametro"] = oLoginParam.NombreParametro;
                                dr2["ValorParametro"] = oLoginParam.ValorParametro;
                                dr2["DescripcionParametro"] = oLoginParam.DescripcionParametro;
                                tb2.Rows.Add(dr2);
                            }
                            dataGridView2.DataSource = tb2;
                        }

                        if (oLoginResp.Permiso != null)
                        {
                            DataTable tb2 = new DataTable("tb1");
                            tb2.Columns.Add("CodigoModulo");
                            tb2.Columns.Add("DescripcionModulo");
                            tb2.Columns.Add("CodigoOpcion");
                            tb2.Columns.Add("NumeroOpcion");
                            tb2.Columns.Add("DescripcionOpcion");
                            tb2.Columns.Add("Permisos");

                            foreach (LoginPermiso oLoginParam in oLoginResp.Permiso)
                            {
                                DataRow dr2 = tb2.NewRow();
                                dr2["CodigoModulo"] = oLoginParam.CodigoModulo;
                                dr2["DescripcionModulo"] = oLoginParam.DescripcionModulo;
                                dr2["CodigoOpcion"] = oLoginParam.CodigoOpcion;
                                dr2["NumeroOpcion"] = oLoginParam.NumeroOpcion;
                                dr2["DescripcionOpcion"] = oLoginParam.DescripcionOpcion;
                                dr2["Permisos"] = oLoginParam.Permisos;
                                tb2.Rows.Add(dr2);
                            }
                            dataGridView3.DataSource = tb2;
                        }



                        Program.Token = oLoginResp.Token ?? "";
                        txtToken.Text = Program.Token;

                        foreach (LoginPermiso lp in oLoginResp.Permiso)
                        {
                            if (lp.CodigoOpcion == "MOV1100") { cmdVerCofresUrnas.Enabled = true; }
                            if (lp.CodigoOpcion == "MOQ1110") { btnEntrega.Enabled = true; }
                        }


                    }

                    Console.WriteLine(responseString);
                }
            }

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


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

        private void cmdVerCofresUrnas_Click(object sender, EventArgs e)
        {
            FrmMostrarImg f = new FrmMostrarImg();
            f.txtUsuario.Text = this.txtUsuario.Text;
            f.ShowDialog();
        }
    }
}
