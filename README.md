# Dating App

Aplikacja randkowa zbudowana z wykorzystaniem **ASP.NET Core 8.0** po stronie backendu oraz **Angular 17** po stronie frontendu. Użytkownicy mogą rejestrować się, tworzyć profile z dodanymi zdjęciami, wyszukiwać potencjalne pary przy użyciu filtrów oraz komunikować się w czasie rzeczywistym z innymi użytkownikami. Aplikacja korzysta z **SQLite** do przechowywania danych, co ułatwia konfigurację i testowanie, a także używa **JWT Token** do bezpiecznej autoryzacji. 

## Funkcjonalności

- **Rejestracja i autoryzacja użytkowników**: Bezpieczna rejestracja i logowanie za pomocą tokenów JWT.
- **Zarządzanie profilem**: Użytkownicy mogą tworzyć i zarządzać swoimi profilami, w tym przesyłać zdjęcia.
- **Wyszukiwanie w czasie rzeczywistym**: Możliwość wyszukiwania potencjalnych par z użyciem filtrów w czasie rzeczywistym (wiek, lokalizacja, zainteresowania itp.).
- **Przesyłanie zdjęć**: Użytkownicy mogą przesyłać i zarządzać swoimi zdjęciami profilowymi.
- **Bezpieczna autoryzacja**: Wszystkie żądania są chronione za pomocą tokenów JWT, co zapewnia bezpieczeństwo danych użytkowników.

## Technologie

- **Frontend**: Angular 17
- **Backend**: ASP.NET Core 8.0
- **Baza danych**: SQLite
- **Autoryzacja**: JWT Token

## Wymagania wstępne

Wymagane narzędzia uruchomieniowe:

- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [.NET SDK](https://dotnet.microsoft.com/download)
- SQLite (do lokalnej bazy danych)
