using bperezT6B.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace bperezT6B.Views;

public partial class vEstudiante : ContentPage
{
    private string url = "http://127.0.0.1/moviles/post.php";
    private readonly HttpClient httpClient = new HttpClient();
    private ObservableCollection<Estudiante> estudiantes = new ObservableCollection<Estudiante>();

    public vEstudiante()
    {
        InitializeComponent();

        Listar();
    }

    public async void Listar()
    {
        var content = await httpClient.GetStringAsync(url);

        List<Estudiante> lstEstudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(content);

        estudiantes = new ObservableCollection<Estudiante>(lstEstudiantes);

        lvEstudiantes.ItemsSource = estudiantes;
    }

    private void btnAbrir_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vInsertarEstudiante());

    }

    private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (Estudiante)e.SelectedItem;

        Navigation.PushAsync(new vActualizarEliminar(objEstudiante));

    }

	private void lvEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is Estudiante seleccionado)
		{
			Navigation.PushAsync(new vActualizarEliminar(seleccionado));
		}
	}
}