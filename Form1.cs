using System.Net;
using System.Net.Mail;
using Renci.SshNet;


namespace TREVENQUE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Seguro que deseas salir de la aplicación?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            DayOfWeek dow = hoy.DayOfWeek; // Sunday=0, Monday=1, ...

            DateTime ultimoLunes;

            if (dow == DayOfWeek.Monday)
            {
                ultimoLunes = hoy.AddDays(-7);
            }
            else
            {
                int offset = ((int)dow - (int)DayOfWeek.Monday);
                if (offset < 0) offset += 7; // Ajuste si es domingo
                ultimoLunes = hoy.AddDays(-offset);
            }

            DateTime ultimoDomingo = ultimoLunes.AddDays(6);

            var semanas = new List<Semana>();

            DateTime inicio = ultimoLunes.AddDays(-365);
            DateTime cursor = inicio;
            int id = 1;

            while (cursor <= ultimoLunes)
            {
                DateTime lunes = cursor;
                DateTime domingo = cursor.AddDays(6);

                semanas.Add(new Semana
                {
                    Id = id,
                    Descripcion = $"Semana {id} ({lunes:dd/MM/yyyy} - {domingo:dd/MM/yyyy})",
                    FechaLunes = lunes,
                    FechaDomingo = domingo
                });

                id++;
                cursor = cursor.AddDays(7);
            }

            cboSemanas.DataSource = semanas;
            cboSemanas.DisplayMember = "Descripcion";
            cboSemanas.ValueMember = "Id";

            // Seleccionar la última semana
            cboSemanas.SelectedIndex = semanas.Count - 1;

            var empresas = new List<Empresa>();

            for (int i = 1; i <= 5; i++)
            {
                empresas.Add(new Empresa
                {
                    Id = i,
                    Nombre = $"empresa_{i.ToString().PadLeft(2, '0')}"
                });
            }

            cboEmpresa.DataSource = empresas;
            cboEmpresa.DisplayMember = "Nombre";
            cboEmpresa.ValueMember = "Id";
            cboEmpresa.SelectedIndex = 0;
        }

        public class Semana
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaLunes { get; set; }
            public DateTime FechaDomingo { get; set; }
        }

        public class Empresa
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            string empresa = cboEmpresa.Text.Trim();
            string semana = cboSemanas.Text.Trim();

            if (string.IsNullOrEmpty(empresa) || string.IsNullOrEmpty(semana))
            {
                MessageBox.Show("Debe seleccionar empresa y semana.");
                return;
            }

            // Extraer fechas entre paréntesis
            int p1 = semana.IndexOf("(");
            int p2 = semana.IndexOf(")");

            string rango = semana.Substring(p1 + 1, p2 - p1 - 1);

            // Ejemplo: "04/03/2024 - 10/03/2024"
            string[] partes = rango.Split(' ');

            DateTime fechaIni = DateTime.Parse(partes[0]);
            DateTime fechaFin = DateTime.Parse(partes[2]);

            string iniUSA = fechaIni.ToString("yyyyMMdd");
            string finUSA = fechaFin.ToString("yyyyMMdd");

            string carpetaExport = @"C:\Users\usuario\Documents\REAL\VFP\002TREVENQUE\EXPORT";
            Directory.CreateDirectory(carpetaExport);

            string salida = Path.Combine(carpetaExport, $"{empresa}_{iniUSA}_{finUSA}.txt");

            string origen = @"C:\Users\usuario\Documents\REAL\VFP\002TREVENQUE\BBDD\ventas.txt";

            if (!File.Exists(origen))
            {
                MessageBox.Show("No existe el fichero ventas.txt");
                return;
            }

            using (var reader = new StreamReader(origen))
            using (var writer = new StreamWriter(salida))
            {
                string linea;

                while ((linea = reader.ReadLine()) != null)
                {
                    string[] campos = linea.Split('|');

                    string fechaLinea = campos[0].Trim();
                    string empresaLinea = campos[1].Trim();

                    DateTime fecha = DateTime.Parse(fechaLinea.Replace("-", "/"));

                    if (empresaLinea == empresa && fecha >= fechaIni && fecha <= fechaFin)
                    {
                        writer.WriteLine(linea);
                    }
                }
            }

            MessageBox.Show("Exportación generada:\n" + salida);

            string tituloCorreo = $"{empresa}_{iniUSA}_{finUSA}";

            var mail = new MailMessage();
            mail.From = new MailAddress("tu_correo@gmail.com");
            mail.To.Add("destinatario@correo.com");
            mail.Subject = tituloCorreo;
            mail.Body = "Adjunto el fichero: " + tituloCorreo;
            mail.Attachments.Add(new Attachment(salida));

            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(
                "tu_correo@gmail.com",
                "CONTRASEÑA_DE_APLICACIÓN"
            );

            smtp.Send(mail);

            MessageBox.Show("Correo enviado correctamente.");

            string host = "ejemploftp.com";
            string user = "ejemplo";
            string pass = "ejemplo";

            string remotePath = "/upload/" + Path.GetFileName(salida);

            using (var sftp = new SftpClient(host, user, pass))
            {
                sftp.Connect();

                using (var fs = new FileStream(salida, FileMode.Open))
                {
                    sftp.UploadFile(fs, remotePath);
                }

                sftp.Disconnect();
            }

            MessageBox.Show("Fichero enviado por SFTP correctamente.");


        }
    }
}
