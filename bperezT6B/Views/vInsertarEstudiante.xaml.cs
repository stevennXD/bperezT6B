using System.Collections.Specialized;
using System.Net;

namespace bperezT6B.Views;

public partial class vInsertarEstudiante : ContentPage
{
    private string url = "http://127.0.0.1/moviles/post.php";

    public vInsertarEstudiante()
    {
        InitializeComponent();
    }

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();

            var parametros = new NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues(url, "POST", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }
}