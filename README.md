Program jest prostą listą to-do z połączeniem do bazy danych MS SQL.
Do programu został użyty EnitityFramework poprzez instalacje NuGet.
Zainstalowane pakiety:
  - Microsoft.EnitityFrameworkCore.SqlServer - v5.0.17
  - Microsoft.EnitityFrameworkCore.Tools - v5.0.17

Aby połączenie z bazą danych działało należy w bazie danych MS SQL połączyć się z bazą (localdb)\Local.
Do tworzenia tabeli jest załączony plik table.sql

Aby obsługiwać operacje na plikach trzeba podawać pełną ścieżkę pliku.
W przypadku pobierania danych z pliku muszą oe być w strukturzę:
  - Jedna linia jeden rekord
  - A karzdej linijce podajemy dwie dane: treść oraz priotytet. De tane muszą być rozdzieloe znakiem '|'
 
