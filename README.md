# MoneyMind

Aplikacja **MoneyMind** to narzędzie do zarządzania budżetem stworzone w technologii ASP.NET Core 8.0. Umożliwia użytkownikom śledzenie przychodów i wydatków, kategoryzowanie transakcji oraz wizualizację danych finansowych za pomocą wykresów. Aplikacja oferuje dwa typy użytkowników: zwykłych i premium, przy czym użytkownicy premium mają dostęp do bardziej zaawansowanych funkcji.

## Wymagania

- **ASP.NET Core 8.0**
- **Visual Studio**
- **SQL Server** (do obsługi bazy danych)
- **Chart.js** (do generowania wykresów)
- **Entity Framework Core** (do operacji na bazie danych)

## Instalacja

1. **Sklonuj repozytorium:**
   ```bash
   git clone https://github.com/piotrMatla/LabProject.git
   ```

2. **Zainstaluj wymagane zależności:**
   - Otwórz rozwiązanie w Visual Studio.
   - Przywróć pakiety NuGet:
     - Narzędzia -> Menedżer pakietów NuGet -> Przywróć pakiety NuGet.

3. **Skonfiguruj połączenie z bazą danych:**
   - Otwórz plik `appsettings.json`.
   - Skonfiguruj odpowiedni łańcuch połączenia z SQL Server w sekcji `LabProjectDbContextConnection` (zamień `DESKTOP-0DG8HLA` na nazwę swojego serwera):
     ```json
     {
       "ConnectionStrings": {
         "LabProjectDbContextConnection": "Server=DESKTOP-0DG8HLA;Database=LabProject;Trusted_Connection=True;TrustServerCertificate=true"
       }
     }
     ```

4. **Utwórz i zastosuj migracje:**
   - Otwórz Konsolę Menedżera Pakietów i uruchom poniższe komendy:
     ```bash
     Add-Migration InitialCreate
     Update-Database
     ```

5. **Uruchom aplikację:**
   - Kliknij `Run` w Visual Studio.

## Struktura bazy danych

Aplikacja wykorzystuje dwa główne konteksty bazy danych:
- **ApplicationDbContext** – kontekst związany z Identity.
- **LabProjectDbContext** – kontekst aplikacji do zarządzania budżetem.

### Tabele:
- **Categories:** Przechowuje kategorie transakcji (np. "Jedzenie", "Transport").
- **Transactions:** Przechowuje dane o transakcjach (przychody lub wydatki).

## Dostępne widoki

### 1. **Strona Główna**
   - Widoczna dla niezalogowanych użytkowników.
   - Opis funkcji aplikacji.
   - Linki do stron logowania i rejestracji.

### 2. **Strona Logowania / Rejestracji**
   - Umożliwia rejestrację nowego konta oraz logowanie.

### 3. **Strona Dashboard**
   - Dostępna dla zalogowanych użytkowników.
   - Podsumowanie finansowe oraz raporty.
   - Wykresy generowane przez Chart.js prezentujące dane finansowe z ostatnich miesięcy.
   - Użytkownicy premium mają dostęp do bardziej szczegółowych raportów.

### 4. **Strona Categories**
   - Umożliwia zarządzanie kategoriami transakcji.
   - Możliwość personalizacji kategorii według potrzeb użytkownika.

### 5. **Strona Transactions**
   - Dodawanie, edycja oraz usuwanie transakcji.
   - Historia transakcji użytkownika.

### 6. **Strona Ustawienia**
   - Umożliwia aktualizację danych osobowych (email, numer telefonu, hasło).

### 7. **Strona Polityki Prywatności**
   - Wyświetla politykę prywatności aplikacji.

## Role użytkowników

### **Użytkownik Premium:**
   - Dostęp do zaawansowanych raportów i analiz.

### **Użytkownik Zwykły:**
   - Przegląd podstawowych raportów.
   - Zarządzanie transakcjami i kategoriami.

---

**MoneyMind** to idealne rozwiązanie dla osób, które chcą efektywnie zarządzać swoimi finansami i lepiej planować swój budżet.
