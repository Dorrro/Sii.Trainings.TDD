namespace Sii.Trainings.TDD.Tests.Excercises
{
    // Pracujesz w firmie obsługującej karty kredytowe, która jako nowy feature dla klienta chce
    // wprowadzić wysyłkę maili z ostrzeżeniem. Ostrzeżenie pojawia się wtedy, kiedy w danej
    // kategorii [zakupów] wydają więcej kasy niż zywkle.

    // - Płatność zdefiniowana jest jako obiekt, który posiada właściwiości: cena, opis i kategoria
    // - Kategorie to po prostu lista of "stuff", np. "rozrywka", "restauracja", itp.
    // - Dla zadanego userId wyszukaj listy płatności z danego i poprzedniego miesiąca
    // - Porównaj ilość pieniędzy wydaną w każdym miesiącu grupując na kategorie. Wybierz te kategorie,
    // w których w tym miesiącu user wydał 50% więcej kasy niż w poprzednim
    // - Stwórz email do użytkownika z listą kategorii, na które wydał wyjątkowo dużo pieniędzy.
    // Tytuł maila powinien brzmieć następująco: "Wykryto nietypowe wydanie 666 PLN!" a treść:
    // "Witaj Użytkowniku Karty,
    //
    //  Wykryliśmy nietypowe wydanie środków na Twojej karcie w następujących kategoriach:
    //  * 222 PLN na zabawki dla dorosłych
    //  * 444 PLN na restauracje
    //  
    //  Pozdrawiamy,
    //  Obsługa Kart Kredytowych"
    public class CreditCardCompanyTests
    {
    }
}
