
namespace katalogMobilny
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        int liczbaProduktow = 5;
        decimal wartoscMagazynu = 500m;

        public MainPage()
        {
            InitializeComponent();
        }


        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            CounterLabel.Text = $"Kliknięto {count} razy";

            SemanticScreenReader.Announce(CounterLabel.Text);


        }

        private void ResetLicznikClicked(object? sender, EventArgs e)
        {
            count = 0;

            CounterLabel.Text = "Kliknięto 0 razy";
        }


        private void PokazClicked(object? sender, EventArgs e)
        {
            EtykietaWyniku.Text = "Wybrano";
        }

        private void UkryjClicked(object? sender, EventArgs e)
        {
            EtykietaWyniku.Text = "Nic nie wybrano";
        }

        private void NazwaProduktu_TextChanged(object? sender, TextChangedEventArgs e)
        {
            LiczbaZnakow.Text = "Liczba znaków: " + NazwaProduktu.Text.Length;
        }


        private async void DodajProdukt_Click(object? sender, EventArgs e)
        {
            string nazwa = NazwaProduktu.Text;
            string ilosc = IloscProduktu.Text;
            string cena = CenaProduktu.Text;
            string kategoria = KategoriaProduktu.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nazwa) ||
                string.IsNullOrWhiteSpace(ilosc) ||
                string.IsNullOrWhiteSpace(cena) ||
                string.IsNullOrWhiteSpace(kategoria))
            {
                await DisplayAlertAsync("Błąd", "Uzupełnij wszystkie pola.", "OK");
                return;
            }

            if (!int.TryParse(ilosc, out int liczba) || liczba <= 0)
            {
                await DisplayAlertAsync("Błąd", "Podaj poprawną ilość.", "OK");
                return;
            }

            if (!decimal.TryParse(cena, out decimal cenaProduktu) ||
                cenaProduktu <= 0)
            {
                await DisplayAlertAsync("Błąd", "Podaj poprawną cenę.", "OK");
                return;
            }

            liczbaProduktow++;

            decimal wartoscProduktu = cenaProduktu * liczba;
            wartoscMagazynu += wartoscProduktu;

            LiczbaProduktow.Text = "Liczba produktów: " + liczbaProduktow;

            WartoscMagazynu.Text = "Wartość magazynu: " +
                wartoscMagazynu.ToString("F2") + " zł";

            if (ListaProduktow.Text == "Brak dodanych produktów")
            {
                ListaProduktow.Text = "";
            }

            ListaProduktow.Text +=
                nazwa + " | Ilość: " + liczba +
                " | Cena: " + cenaProduktu.ToString("F2") +
                " zł | Kategoria: " + kategoria + "\n";

            NazwaProduktu.Text = "";
            IloscProduktu.Text = "";
            CenaProduktu.Text = "";
            KategoriaProduktu.SelectedIndex = -1;

            LiczbaZnakow.Text = "Liczba znaków: 0";
        }

        
        private void ResetClicked(object? sender, EventArgs e)
        {
            liczbaProduktow = 5;
            wartoscMagazynu = 500m;

            LiczbaProduktow.Text = "Liczba produktów: 5";
            WartoscMagazynu.Text = "Wartość magazynu: 500,00 zł";

            ListaProduktow.Text = "Brak dodanych produktów";

            NazwaProduktu.Text = "";
            IloscProduktu.Text = "";
            CenaProduktu.Text = "";
            KategoriaProduktu.SelectedIndex = -1;

            LiczbaZnakow.Text = "Liczba znaków: 0";
        }
    }
}
