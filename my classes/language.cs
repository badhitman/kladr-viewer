using System;
using System.Collections.Generic;

namespace KLADR_viewer_v4.my_classes
{
    static class Language
    {
        public static Languages DetectLang(string stringName)
        {
            foreach (Languages lang in Enum.GetValues(typeof(Languages)))
            {
                if (lang.ToString() == stringName)
                    return lang;
            }
            return Languages.English;
        }

        public enum Languages { English, Deutsch, Русский };

        public static class Other
        {
            public static string Create_connect_to_dbf_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Es schafft eine Verbindung zu DBF"}
                    ,{Languages.English,"Create connect to DBF..."}
                    ,{Languages.Русский,"Создаётся подключение к DBF"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Unable_to_connect_to_db
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Kann nicht zur Datenbank verbinden КЛАДР. Убедитесь, что в указанной папке присутствуют файлы КЛАДР\n\n\"KLADR.DBF\"\n\"STREET.DBF\"\n\"DOMA.DBF\"\n\n"}
                    ,{Languages.English,"Unable to connect to the database КЛАДР.\nMake sure the specified folder are the files КЛАДР\n\n\"KLADR.DBF\"\n\"STREET.DBF\"\n\"DOMA.DBF\"\n\n"}
                    ,{Languages.Русский,"Не удалось подключиться к базе данных КЛАДР.\nУбедитесь, что в указанной папке присутствуют файлы КЛАДР\n\n\"KLADR.DBF\"\n\"STREET.DBF\"\n\"DOMA.DBF\"\n\n"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Error_connect_to_db
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Connection Error!"}
                    ,{Languages.English,"Error connecting!"}
                    ,{Languages.Русский,"Ошибка подключения!"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Create_connect
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Erstellen Sie eine Verbindung mit dem SQLite..."}
                    ,{Languages.English,"Create connect SQLite..."}
                    ,{Languages.Русский,"Создаём подключение к SQLite..."}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Transfer_records_socrbase
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Datensätze importieren 'SOCRBASE' DBF->SQLite"}
                    ,{Languages.English,"Transfer records 'SOCRBASE' DBF->SQLite"}
                    ,{Languages.Русский,"Импорт записей 'SOCRBASE' DBF->SQLite"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Test_correct_dbf_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Prüfung der Richtigkeit DBF"}
                    ,{Languages.English,"Testing the correctness DBF..."}
                    ,{Languages.Русский,"Тестирование корректности DBF..."}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Transfer_records_kladr
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"übertragen 'KLADR' DBF->SQLite..."}
                    ,{Languages.English,"Transfer records 'KLADR' DBF->SQLite..."}
                    ,{Languages.Русский,"Перенос 'KLADR' DBF->SQLite..."}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Create_data_base_to_region
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Erstellen einer SQLite-Datenbank für die Region"}
                    ,{Languages.English,"Create Data Base's SQLite to region"}
                    ,{Languages.Русский,"Создание базы данных SQLite для региона"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Transfer_records_street
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"übertragen 'STREET' DBF->SQLite..."}
                    ,{Languages.English,"Transfer records 'STREET' DBF->SQLite..."}
                    ,{Languages.Русский,"Перенос 'STREET' DBF->SQLite..."}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Transfer_records_doma
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"übertragen 'DOMA' DBF->SQLite..."}
                    ,{Languages.English,"Transfer records 'DOMA' DBF->SQLite..."}
                    ,{Languages.Русский,"Перенос 'DOMA' DBF->SQLite..."}
                    }[Global.CurrentLNG];
                }
            }
            public static string Indexing_sqlitq_database_to_region
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Indizierung von SQLite-Datenbank (region"}
                    ,{Languages.English,"Indexing SQLite Data Base (region"}
                    ,{Languages.Русский,"Индексирование SQLite базы данных (регион"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Create_connect_to_dbf
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Erstellen einer Verbindung zu DBF"}
                    ,{Languages.English,"Create connect to DBF..."}
                    ,{Languages.Русский,"Создание подключения к DBF"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Connected_to_data_base_of_open
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Verbindung mit der Region"}
                    ,{Languages.English,"connected to the base region"}
                    ,{Languages.Русский,"подключение к базе региона"}
                    }[Global.CurrentLNG];
                }
            }
        }

        public static class FormCreateDB
        {
            public static string Window_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Erstellen einer neuen Datenbank "+Global.preficsBildProgramm}
                    ,{Languages.English,"Create new data base "+Global.preficsBildProgramm}
                    ,{Languages.Русский,"Создание новой базы данных "+Global.preficsBildProgramm}
                    }[Global.CurrentLNG];
                }
            }
            public static string Label_name_data_base_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Database Name:"}
                    ,{Languages.English,"Name database:"}
                    ,{Languages.Русский,"Имя базы данных:"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Label_name_data_base_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Der Name der Datenbank (lokale Ordner in Windows)"}
                    ,{Languages.English,"The name of the database (including the name of the folder in windows)"}
                    ,{Languages.Русский,"Имя базы данных (локальная папка в Windows)"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Folder_GNIVC_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Ordner DB ГНИВЦ"}
                    ,{Languages.English,"Folder DB ГНИВЦ:"}
                    ,{Languages.Русский,"Папка DB ГНИВЦ"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Folder_GNIVC_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Zusammensetzung und Struktur des Klassifikators\r\n"+
                         "\r\n"+
                    "Auf magnetischen Medien wird ein Klassifikator in den folgenden Formular DBF-Dateien konzipiert:\r\n"+
                    "Datei Kladr.dbf - enthält Datensätze mit den Gegenständen der ersten vier Gliederungsebenen (Regionen, Bezirke (Ulus), die Stadt, Städte, Gemeinderäte, ländliche Gebiete);\r\n"+
                    "Datei Street.dbf - enthält Datensätze mit den Objekten der fünften Ebene der Einstufung (die Straßen der Städte und Gemeinden);\r\n"+
                    "Datei Doma.dbf - enthält Datensätze mit den Objekten der sechsten Ebene der Einstufung (Anzahl der Häuser Straßen der Städte und Gemeinden);\r\n"+
                    "Datei Flat.dbf - enthält Datensätze mit den Objekten der siebten Ebene der Einstufung (Zahl der Wohnungen Häuser);\r\n"+
                    "Datei Socrbase.dbf - enthält Datensätze mit kurzen Namen von Arten von Websites gezielt;\r\n"+
                    "Altnames.dbf-Datei enthält Informationen über die Einhaltung von Datensätzen alten und neuen Namen der Zielobjekte, sowie Informationen über den anvisierten Objekt-Code Compliance vor und nach ihrer Versetzung."}
                    ,{Languages.English,"Composition and structure of the classifier\r\n"+
                    "On magnetic media, a classifier is designed in the following form DBF-files:\r\n"+
                    "File Kladr.dbf - contains records with the objects of the first four classification levels (regions, districts (ulus), the city, towns, village councils, rural areas);\r\n"+
                    "File Street.dbf - contains records with the objects of the fifth level of classification (the streets of cities and towns);\r\n"+
                    "File Doma.dbf - contains records with the objects of the sixth level of classification (number of houses streets of cities and towns);\r\n"+
                    "File Flat.dbf - contains records with the objects of the seventh level of classification (number of apartments houses);\r\n"+
                    "File Socrbase.dbf - contains records with short names of types of targeted sites;\r\n"+
                    "Altnames.dbf-file contains information about compliance with codes of records old and new names of targeted objects, as well as information about the targeted object code compliance before and after their reassignment"}
                    ,{Languages.Русский,"Состав и структура классификатора\r\n"+
                        "\r\n"+
                    "На магнитных носителях классификатор оформлен в виде следующих DBF-файлов:\r\n"+
                    "файл Kladr.dbf – содержит записи с объектами первых четырех уровней классификации (регионы; районы (улусы); города, поселки городского типа, сельсоветы; сельские населенные пункты);\r\n"+
                    "файл Street.dbf – содержит записи с объектами пятого уровня классификации (улицы городов и населенных пунктов);\r\n"+
                    "файл Doma.dbf – содержит записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);\r\n"+
                    "файл Flat.dbf  – содержит записи с объектами седьмого уровня классификации (номера квартир домов);\r\n"+
                    "файл Socrbase.dbf – содержит записи с краткими наименованиями типов адресных объектов;\r\n"+
                    "файл Altnames.dbf –содержит сведения о соответствии кодов записей со старыми и новыми наименованиями адресных объектов, а также сведения о соответствии кодов адресных объектов до и после их переподчинения"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Text_box_log_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Progress-Datenbank Import-Programm"}
                    ,{Languages.English,"Progress import the database into the program"}
                    ,{Languages.Русский,"Прогресс импорта базы данных в программе"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Button_start_transfer
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"starten Sie importieren"}
                    ,{Languages.English,"Start transfer"}
                    ,{Languages.Русский,"Начать импорт"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Button_close
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Schließen"}
                    ,{Languages.English,"Close"}
                    ,{Languages.Русский,"Закрыть"}
                    }[Global.CurrentLNG];
                }
            }
        }

        public static class FormKLADRtoCSV
        {
            public static string Window_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Konverter/import *. DBF to *. CSV "+Global.preficsBildProgramm}
                    ,{Languages.English,"converter/import *.DBF to *.CSV "+Global.preficsBildProgramm}
                    ,{Languages.Русский,"Поиск в классификаторе "+Global.preficsBildProgramm}
                    }[Global.CurrentLNG];
                }
            }
            public static string Label_info
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Zum Konvertieren von DBF-Dateien in CSV genug, um die gewünschte Datei und\r\n"+
                    "drücken Sie Import DBF auszuwählen. Import Tool erstellt eine Datei in einem Ordner\r\n"+
                    "mit dem Namen der ursprünglichen Datei, aber mit der Endung CSV. Import Tool wurde\r\n"+
                    "vor allem für KLADR-Viewer erstellt, aber es ist nicht auf diese Dateien beschränkt.\r\n"+
                    "Sie können dieses Tool verwenden, um DBF-Datei ohne Einschränkungen zu\r\n"+
                    "importieren. Die resultierende Datei ist eine gültige CSV-Datei und kann verwendet\r\n"+
                    "werden, zu importieren/exportieren (zB Import in MySQL, über phpMyAdmin, etc.)\r\n"+
                    "und für andere Zwecke sein."}
                    ,{Languages.English,"To convert a DBF file in CSV enough to select the desired DBF file and click\r\n"+
                    "Import. Import Tool creates a file in a folder titled with the original file, but\r\n"+
                    "with the extension CSV. Import Tool was created primarily for the viewer of\r\n"+
                    "the classifier, but it is not limited only to these files. You can use this tool to\r\n"+
                    "import a DBF file without any restrictions. The resulting file is a valid CSV file\r\n"+
                    "and can easily be used in the import / export such as MySQL (for example\r\n"+
                    "through PHPMyAdmin, etc.) and any other needs."}
                    ,{Languages.Русский,"Чтобы преобразовать DBF файлы в CSV достаточно выбрать нужный файл DBF\r\n"+
                    "и нажать Импорт. Инструмент импорта создает одноимённый файл в папке\r\n"+
                    "оригинального файла, но с расширением CSV. Инструмент импорта был создан\r\n"+
                    "в первую очередь для КЛАДР-Viewer, но он не ограничивается только этими\r\n"+
                    "файлами. Вы можете использовать этот инструмент для импорта DBF файлов\r\n"+
                    "без каких-либо ограничений. Полученный файл является валидным CSV файлом\r\n"+
                    "и может быть использован в импорте/экспорте (например\r\n"+
                    "импорт в MySQL, через PHPMyAdmin, и т.д.) и для любых других нужд."}
                    }[Global.CurrentLNG];
                }
            }
            public static string Button_import_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Importe"}
                    ,{Languages.English,"Import"}
                    ,{Languages.Русский,"Импорт"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Button_close_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Schließen"}
                    ,{Languages.English,"Close"}
                    ,{Languages.Русский,"Закрыть"}
                    }[Global.CurrentLNG];
                }
            }
        }

        public static class FormSearch
        {
            public static string Window_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Suchen Sie in Klassifikator "+Global.preficsBildProgramm}
                    ,{Languages.English,"Search in Classifier "+Global.preficsBildProgramm}
                    ,{Languages.Русский,"Поиск в классификаторе "+Global.preficsBildProgramm}
                    }[Global.CurrentLNG];
                }
            }
            public static string Label_qoery_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Abfrage:"}
                    ,{Languages.English,"Query:"}
                    ,{Languages.Русский,"Запрос:"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Label_qoery_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"In der Standardeinstellung ist die Suche Groß-und Kleinschreibung, aber es ist möglich die Suche mit T-SQL-Ausdrucks-und Groß-und Kleinschreibung\r\n"+
                        "(Sie setzen den Ausdruck in geschweiften Klammern {}. Beispiel {meineSuchanfrageStadt___%})"}
                    ,{Languages.English,"By default the search is case insensitive, but it is possible to search using T-SQL expression and case sensitive\r\n"+
                    "(you put the expression in curly braces {}. Example {mySearchQueryCity___%})"}
                    ,{Languages.Русский,"По умолчанию поиск не чувствителен к регистру, но можно искать с помощью T-SQL выражений, и/или с учётом регистра\r\n"+
                         "(поместите ваше выражение в фигурные скобки {}. Пример {мойПоисковыйЗапросГорода___%})"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Button_start_search_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Suche"}
                    ,{Languages.English,"Search"}
                    ,{Languages.Русский,"Поиск"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Button_start_search_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Suche starten"}
                    ,{Languages.English,"Starting search"}
                    ,{Languages.Русский,"Начать поиск"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Where_look_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Ausgewählte Bereiche der Suche. Wählen Sie alle oder einige der gewünschten Bereichen.\r\n"+
                        "Je kleiner die gewählte Regionen der schnelleren Suche ist vorbei"}
                    ,{Languages.English,"Selected regions of the search. Select all or desired regions.\r\n"+
                    "The smaller the selected regions of the faster search"}
                    ,{Languages.Русский,"Выбранные регионы поиска. Выбрать все или несколько желаемых регионов.\r\n"+
                         "Чем меньше выбрано регионов тем быстрее закончится поиск"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Where_look_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"wo sie suchen?"}
                    ,{Languages.English,"where to look?"}
                    ,{Languages.Русский,"где искать?"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Deselect_all_items_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Deaktivieren Sie alle"}
                    ,{Languages.English,"Unselect all regions"}
                    ,{Languages.Русский,"Снять выделение везде"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Invert_select_items_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Auswahl umkehren"}
                    ,{Languages.English,"Invert select regions"}
                    ,{Languages.Русский,"Инвертировать выделение"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Select_all_items_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Wählen Sie alle"}
                    ,{Languages.English,"Select all regions"}
                    ,{Languages.Русский,"Выбрать все"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Grid_view_result_search_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Diese Suchergebnisse"}
                    ,{Languages.English,"Result data of search"}
                    ,{Languages.Русский,"Данные результата поиска"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Search_in
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Suche in der"}
                    ,{Languages.English,"search in"}
                    ,{Languages.Русский,"поиск в"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Search_of
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch," von "}
                    ,{Languages.English," of "}
                    ,{Languages.Русский," из "}
                    }[Global.CurrentLNG];
                }
            }
        }

        public static class FormSettings
        {
            public static string Title_window
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Einstellungen "+Global.preficsBildProgramm}
                    ,{Languages.English,"Settings "+Global.preficsBildProgramm}
                    ,{Languages.Русский,"Настройки "+Global.preficsBildProgramm}
                    }[Global.CurrentLNG];
                }
            }
            public static string Lang_app_groupbox_tex
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Die Sprache des Programms"}
                    ,{Languages.English,"Language of application"}
                    ,{Languages.Русский,"Выберите язык для программы"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Chose_lang_programm_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Wählen Sie die bevorzugte Sprache für das Programm"}
                    ,{Languages.English,"Please choose the preferred language for the program"}
                    ,{Languages.Русский,"Выберите нужный язык для программы"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Group_box_time_aut_cash
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Timeout-Caching"}
                    ,{Languages.English,"Engine cache timeout"}
                    ,{Languages.Русский,"Таймаут механизма кэширования"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Label_time_aut_cash
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Das Timeout der Abfrage an die Datenbank Auswahl eines Knotens im Baum KLADR.Wenn der Wahl einiger\r\n" +
                     "Knoten im Baum dauert länger KLADR ausgewählte Wert (zB 150 Millisekunden mehr), dann die Wahl wird\r\n" +
                     " zwischengespeichert und anschließende Gespräche werden aus dem Ergebnis-Cache genommen werden"}
                    ,{Languages.English,"The timeout of the query to the database selection of a node in the tree KLADR. If the\r\n"+
                    "choice of some nodes in the tree takes longer KLADR selected value (eg 150 milliseconds\r\n"+
                    "longer), then the choice will be cached and subsequent calls will be taken from the result cache"}
                    ,{Languages.Русский,"Тайм-аут запроса к базе данных Выбора узла в дереве КЛАДР. Если выбор некоторых\r\n" +
                     " узлов в дереве занимает много времени (например, более 150 миллисекунд), то результат\r\n" +
                     " выбора будет смохранён в кэше и последующие вызовы будут взяты из кэша результатов"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Label_ms_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"millisekunden"}
                    ,{Languages.English,"milliseconds"}
                    ,{Languages.Русский,"миллисекунд"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Group_box_folder_database_program
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Ordner-Datenbank-Programm"}
                    ,{Languages.English,"Folder database program"}
                    ,{Languages.Русский,"Папка базы данных программы"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Label_folder_database_program_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Geben Sie den Ordner, wo das Programm seine Daten gespeichert werden. Sie können einen beliebigen\r\n"+
                     "Ordner auf Ihrem PC oder Ordners im Netzwerk. Standardmäßig werden die Dokumente\r\n" +
                     "\"KLADR-Viewer\"-Ordner Ihres Benutzer-Verzeichnis wird erstellt und es wird ein Ordner erstellt Datenbanken"}
                    ,{Languages.English,"Specify the folder where the program will store its data KLADR. You can specify any folder\r\n"+
                    "on your PC or netbios address of the folder on the network. By default, the documents\r\n"+
                    "folder of your user directory is created \"KLADR-Viewer\" and it creates a folder databases"}
                    ,{Languages.Русский,"Укажите папку, в которой программа будет хранить свои данные КЛАДР. Можно указать любую\r\n"+
                     "папку на компьютере или папку в сети. По умолчанию в папке документовпользователя\r\n" +
                     "создается каталог \"КЛАДР-Viewer \", и уже в этой папке созлаются каталоги с базами данных"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Button_reset_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Auf Standard zurücksetzen"}
                    ,{Languages.English,"Reset to Defaults"}
                    ,{Languages.Русский,"Сброс на стандартные"}
                    }[Global.CurrentLNG];
                }
            }
        }

        public static class FormStart
        {
            static public string File_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Datei"}
                    ,{Languages.English,"File"}
                    ,{Languages.Русский,"Файл"}
                    }[Global.CurrentLNG];
                }
            }
            public static string File_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Datei"}
                    ,{Languages.English,"File"}
                    ,{Languages.Русский,"Файл"}
                    }[Global.CurrentLNG];
                }

            }
            static public string Create_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Erstellen"}
                    ,{Languages.English,"Create"}
                    ,{Languages.Русский,"Создать"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Create_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Erstellen Sie eine neue Datenbank aus dem Daten KLADR ГНИВЦ"}
                    ,{Languages.English,"Create a new database from the base classifier"}
                    ,{Languages.Русский,"Создать новую базу данных из данных КЛАДР ГНИВЦ"}
                    }[Global.CurrentLNG];
                }
            }
            static public string Open_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Öffnen"}
                    ,{Languages.English,"Open"}
                    ,{Languages.Русский,"Открыть"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Open_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Öffnen Sie die Datenbank"}
                    ,{Languages.English,"Open the database"}
                    ,{Languages.Русский,"Открыть базу данных"}
                    }[Global.CurrentLNG];
                }
            }
            static public string Exit_text
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Ausgang"}
                    ,{Languages.English,"Exit"}
                    ,{Languages.Русский,"Выход"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Exit_tool_tip
            {
                get
                {
                    return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Schließen Sie das Programm"}
                    ,{Languages.English,"Close the program"}
                    ,{Languages.Русский,"Закрыть программу"}
                    }[Global.CurrentLNG];
                }
            }
            public static string Service_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Service"}
                    ,{Languages.English,"Service"}
                    ,{Languages.Русский,"Сервис"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Service_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Service"}
                    ,{Languages.English,"Service"}
                    ,{Languages.Русский,"Сервис"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Search_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Suche"}
                    ,{Languages.English,"Search"}
                    ,{Languages.Русский,"Поиск"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Search_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Suchen Sie nach Titeln in der Datenbank"}
                    ,{Languages.English,"Find items in the database"}
                    ,{Languages.Русский,"Поиск элементов по базе данных"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Dbf_to_csv_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"KL&ADR im &CSV"}
                    ,{Languages.English,"KL&ADR to &CSV"}
                    ,{Languages.Русский,"KL&ADR в &CSV"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Dbf_to_csv_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Convert DBF-Dateien im CSV-Format"}
                    ,{Languages.English,"Convert DBF files to CSV format"}
                    ,{Languages.Русский,"Конвертировать DBF файлы в формат CSV"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Settings_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Einstellungen"}
                    ,{Languages.English,"Settings"}
                    ,{Languages.Русский,"Настройки"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Settings_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Programm-Einstellungen"}
                    ,{Languages.English,"Programm settings"}
                    ,{Languages.Русский,"Настройки программы"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string TextWindow
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Russland Classifier von mail-Adressen "+Global.preficsBildProgramm}
                    ,{Languages.English,"Russia Classifier of mail addresses "+Global.preficsBildProgramm}
                    ,{Languages.Русский,"Классификатор почтовых адресов РФ "+Global.preficsBildProgramm}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Help_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Auskunft"}
                    ,{Languages.English,"Help"}
                    ,{Languages.Русский,"Справка"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Help_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Die Auskunft über das Programm"}
                    ,{Languages.English,"Help programm"}
                    ,{Languages.Русский,"Справка по программе"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Desc_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Beschreibung"}
                    ,{Languages.English,"Description"}
                    ,{Languages.Русский,"Описание"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string Desc_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Beschreibung"}
                    ,{Languages.English,"Description"}
                    ,{Languages.Русский,"Описание"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string About_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Über das Programm"}
                    ,{Languages.English,"About the program"}
                    ,{Languages.Русский,"О программе"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _about_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Über das Programm"}
                    ,{Languages.English,"About the program"}
                    ,{Languages.Русский,"О программе"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _tree_start_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Das Objekt Baum Klassifikator"}
                    ,{Languages.English,"The object tree classifier address"}
                    ,{Languages.Русский,"Дерево объектов классификатора"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _data_grid_view_detail_start_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Die Gegenstände der Sichter-Adressen sind in den ausgewählten Knoten des Baumes Klassifikator\r\n"}
                    ,{Languages.English,"Objects of address classifier embedded in the selected node from the tree classifier\r\n(table rows are grouped by type of facility and highlighted different background)"}
                    ,{Languages.Русский,"Объекты классификатора адресов находящиеся в выбранном узле из дерева классификатора\n\r(Zeilen werden nach der Art der Anlage gruppiert und hob die verschiedenen Hintergrund)"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _name_title_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Namen der Anlage:"}
                    ,{Languages.English,"Name of the object:"}
                    ,{Languages.Русский,"Наименование:"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _name_title_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"\"Der Name des Objekts \"enthält die Namen der gezielten Ebenen der Klassifikation von Objekten 4.1. Länge des Namens darf maximal 40 Zeichen\r\n\r\n" +
                    "\"Kurzname des Objekttyps \"enthält den abgekürzten Namen der Adresse des Objekts 1 -. 4 Ebenen der Klassifikation \r\n" +
                    "Die Länge dieser Name sollte nicht länger als 10 Zeichen Werte Akronym Art der Adresse des Objekts 1 -. 4 Ebenen der Klassifikation sind \r\n" +
                    "In Anlage 1 zu der Beschreibung des Qualifier befasst sich mit der Russischen Föderation (KLADR)"}
                    ,{Languages.English,"\"Project Name\" contains the names of the objects targeted 4.1 classification levels. The length of the name must not exceed 40 characters\r\n\r\n"+
                    "\"Abbreviated name of the object type\" contains the abbreviated name of the address type of the object 1 - 4 levels of classification.\r\n"+
                    "The length of this name should not exceed 10 characters. Valid values ​​acronym type the address of the object 1 - 4 levels of classification are presented\r\n"+
                    "in Appendix 1 to the description of the qualifier addresses the Russian Federation (KLADR)"}
                    ,{Languages.Русский,"\"Наименование объекта\" содержит наименования адресных объектов 1-4 уровней классификации. Длина наименования не должна превышать 40 символов\r\n\r\n"+
                     "\"Сокращенное наименование типа объекта\" содержит сокращённое наименование типа адресного объекта 1 – 4 уровня классификации.\r\n"+
                    "Длина этого наименования не должна превышать 10 символов. Допустимые значения сокращенного наименования типа адресного объекта 1 – 4 уровня классификации представлены\r\n"+
                    "в Приложении 1 к Описанию классификатора адресов Российской Федерации (КЛАДР)"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _code_kladr_tool_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Kode im КЛАДР:"}
                    ,{Languages.English,"Code of КЛАДР:"}
                    ,{Languages.Русский,"Код в КЛАДР:"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _code_kladr_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"\"Der Kode\" nimmt den Identifizierungskode des Adressobjektes 1 – 4 Niveaus der Klassifikation und das Merkmal seiner Aktualität auf.\r\n"+
                    "Der Identifizierungskode wird unter Ausnutzung der hierarchischen Methode der Klassifikation und der konsequenten Methode der Kodierung innerhalb der Klassifikationsgruppierung gebaut.\r\n"+
                    "Das Merkmal der Aktualität kann die folgenden Bedeutungen übernehmen:\r\n"+
                    "“00” – das aktuelle Objekt (seine Benennung, die Unterordnung entsprechen dem Zustand zur Zeit des Adressraumes).\r\n"+
                    "“01” - “50” – war das Objekt umbenannt, in der vorliegenden Aufzeichnung ist eine seiner vorigen Benennungen (aktuell adress- gebracht\r\n"+
                    "Das Objekt ist in der Datenbank mit dem selben Kode, aber mit dem Merkmal der Aktualität \"00 anwesend\";\r\n"+
                    "“51” – war das Objekt переподчинен oder hat sich dem Bestand anderen Objektes (angeschlossen das aktuelle Adressobjekt klärt sich nach der Basis Altnames.dbf);\r\n"+
                    "“52” - “98” – die Reservebedeutungen des Merkmales der Aktualität;\r\n"+
                    "”99” – existiert das Adressobjekt nicht, d.h. es gibt kein aktuelles ihm entsprechende Adressobjekt.\r\n"+
                    "Die Länge des Merkmales der Aktualität – zwei Kategorien. Die Länge des Identifizierungskodes - 11 Kategorien.\r\n"+
                    "\r\n"+
                    "Die Struktur der Kodebezeichnung im Block \"Kode\":\r\n"+
                    "Die SS RRR GGG PPP АА, wo\r\n"+
                    "Die SS – der Kode des Subjektes der Russischen Föderation (die Region), sind die Kodes der Regionen in der Anlage 2 zur Beschreibung des Klassierers der Adressen der Russischen Föderation (КЛАДР) vorgestellt;\r\n"+
                    "РРР – der Kode des Bezirkes;\r\n"+
                    "ГГГ – der Kode der Stadt;\r\n"+
                    "ППП – der Kode des Ortes,\r\n"+
                    "АА – das Merkmal der Aktualität des Adressobjektes"}
                    ,{Languages.English,"\"Code\" includes an identification code of the targeted object 1 - 4 levels of classification and a sign of its relevance.\r\n"+
                    "The identification code is constructed using the method of hierarchical classification and consistent method of coding within the classification groups.\r\n"+
                    "Relevance may be a sign of the following values:\r\n"+
                    "“00” - the actual object (its name, the subordination of the match at the moment of the address space).\r\n"+
                    "“01”-“50” - the object was renamed in the record shows one of his previous titles (current address object is present in the database with the same code, but with the sign of the relevance of \"00\";\r\n"+
                    "“51” - the object has been reassigned or merged into another object (the actual address of an object is determined based Altnames.dbf);\r\n"+
                    "“52”-“98” - back relevance of the characteristic value;\r\n"+
                    "”99” - targeted object does not exist, ie No actual address of the corresponding object.\r\n"+
                    "The length attribute relevance - two digits. The length of the identification code - 11 digits.\r\n"+
                    "\r\n"+
                    "Code structure in the block \"code\":\r\n"+
                    "SS RRR GGG PPP AA, where\r\n"+
                    "CC - Code of the Russian Federation (the region), region codes are presented in Appendix 2 to the description of the qualifier addresses the Russian Federation (KLADR);\r\n"+
                    "PPP - the area code;\r\n"+
                    "GGG - city code;\r\n"+
                    "RFP - area code,\r\n"+
                    "AA - a sign of the relevance of the address object"}
                    ,{Languages.Русский,"\"Код\" включает идентификационный код адресного объекта 1 – 4 уровня классификации и признак его актуальности.\r\n"+
                    "Идентификационный код строится с использованием иерархического метода классификации и последовательного метода кодирования внутри классификационной группировки.\r\n"+
                    "Признак актуальности может принимать следующие значения:\r\n"+
                    "“00” – актуальный объект (его наименование, подчиненность соответствуют состоянию на данный момент адресного пространства).\r\n"+
                    "“01”-“50” – объект был переименован, в данной записи приведено одно из прежних его наименований (актуальный адресный объект присутствует в базе данных с тем же кодом, но с признаком актуальности “00”;\r\n"+
                    "“51” –  объект был переподчинен или влился в состав другого объекта (актуальный адресный объект определяется по базе Altnames.dbf);\r\n"+
                    "“52”-“98” – резервные значения признака актуальности;\r\n"+
                    "”99” – адресный объект не существует, т.е. нет соответствующего ему актуального адресного объекта.\r\n"+
                    "Длина признака актуальности – два разряда. Длина идентификационного кода  - 11 разрядов.\r\n"+
                    "\r\n"+
                    "Структура кодового обозначения в блоке \"Код\":\r\n"+
                    "СС РРР ГГГ ППП АА, где\r\n"+
                    "СС – код субъекта Российской Федерации (региона), коды регионов представлены в Приложении 2 к Описанию классификатора адресов Российской Федерации (КЛАДР);\r\n"+
                    "РРР – код района;\r\n"+
                    "ГГГ – код города;\r\n"+
                    "ППП – код населенного пункта,\r\n"+
                    "АА – признак актуальности адресного объекта"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _priznak_aktualnosti_00
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Tatsächliches Objekt (seinen Namen, Unterordnung entsprechen dem Stand zum Zeitpunkt des Adressenraums)"}
                    ,{Languages.English,"Actual object (its name, subordination correspond to the state at the moment of the address space)"}
                    ,{Languages.Русский,"Актуальный объект (его наименование, подчиненность соответствуют состоянию на данный момент адресного пространства)"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _priznak_aktualnosti_01_50
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Das Objekt wurde in diesem Eintrag umbenannt wird einer seiner früheren Namen (aktuelle Adresse Objekt in der Datenbank mit dem gleichen Code vorhanden, aber mit einem Schild Bedeutung “00” gegeben"}
                    ,{Languages.English,"The object has been renamed in this entry is given one of his former names (current address object is present in the database with the same code, but with a sign relevance “00”"}
                    ,{Languages.Русский,"Объект был переименован, в данной записи приведено одно из прежних его наименований (актуальный адресный объект присутствует в базе данных с тем же кодом, но с признаком актуальности “00”"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _priznak_aktualnosti_51
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Das Objekt zugewiesen oder in dem anderen Objekt verbunden (Objekt-to-date-Adresse ist auf der Grundlage Altnames.dbf bestimmt) wurde"}
                    ,{Languages.English,"The object was reassigned or joined in the other object (object-to-date address is determined based on Altnames.dbf)"}
                    ,{Languages.Русский,"Объект был переподчинен или влился в состав другого объекта (актуальный адресный объект определяется по базе Altnames.dbf)"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _priznak_aktualnosti_52_98
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Backup-Funktion Wert Bedeutung"}
                    ,{Languages.English,"Backup feature value relevance"}
                    ,{Languages.Русский,"Резервные значения признака актуальности"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _priznak_aktualnosti_99
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Addressable-Objekt nicht vorhanden, das heißt keine entsprechende tatsächliche Adresse des Objekts"}
                    ,{Languages.English,"Addressable object does not exist, i.e. no corresponding actual address of the object"}
                    ,{Languages.Русский,"Адресный объект не существует, т.е. нет соответствующего ему актуального адресного объекта"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _index_kladr_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Postleitzahl:"}
                    ,{Languages.English,"Postal index:"}
                    ,{Languages.Русский,"Почтовый индекс:"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _index_kladr_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"\"Die Postleitzahl\" enthält die Postleitzahl des Unternehmens der postalischen Verbindung,\r\n"+
                    "das das vorliegende Adressobjekt bedient. Die Länge der Postleitzahl – 6 Kategorien"}
                    ,{Languages.English,"\"Zip code\" contains the postal code Company postal\r\n"+
                    "service address this subject. The length zip - 6 digits"}
                    ,{Languages.Русский,"\"Почтовый индекс\" содержит почтовый индекс предприятия почтовой связи,\r\n"+
                    "обслуживающего данный адресный объект. Длина почтового индекса – 6 разрядов"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _gninmb_kladr_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Kode ИФНС:"}
                    ,{Languages.English,"Code ИФНС:"}
                    ,{Languages.Русский,"Код ИФНС:"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _gninmb_kladr_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"\"Kode ИФНС\" contains the code inspectorate of federal agency of federal tax service of Russia classifier \"notation of the tax\r\n"+
                    "bodies\" (SONO), serving the territory, on which is located the address object. The code length - 4 digits"}
                    ,{Languages.English,"\"ИФНС Code\" contains the code for the Russian Federal Tax Service Inspectorate departmental FTS Russia Classifier \"The notation\r\n"+
                    "of the tax authorities\" (СОНО), the serving area, which is currently targeted object. The length of the code - 4 digits"}
                    ,{Languages.Русский,"\"Код ИФНС\" содержит код инспекции ФНС России по ведомственному ФНС России классификатору \"Система обозначений\r\n"+
                    "налоговых органов\" (СОНО), обслуживающей территорию, на которой расположен данный адресный объект. Длина кода – 4 разряда"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _uno_kladr_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Land ИФНС:"}
                    ,{Languages.English,"Land ИФНС:"}
                    ,{Languages.Русский,"Участок ИФНС:"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _uno_kladr_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"\"Code der territoriale Bereich ИФНС\" beinhaltet die territoriale Vorwahl *\r\n"+
                    "(abgeschafft Inspektion in die Einheit kreisübergreifenden Inspektorat umgewandelt:\r\n"+
                    "Front, den territorialen Bereich, etc.) ИФНС Russland auf Abteilungsebene Handbuch Codes\r\n"+
                    "der Steuerbehörden für die Zwecke des Steuerpflichtigen (СОУН), Service-Bereich , der derzeit\r\n"+
                    "Gegenstand ausgerichtet. Die Länge der Code - 4-stellig"}
                    ,{Languages.English,"\"Code of the territorial area ИФНС\" includes the territorial area code *\r\n"+
                    "(abolished inspection, transformed into a unit of inter-district inspectorate:\r\n"+
                    "Front, the territorial area, etc.) ИФНС Russia on a departmental directory, codes\r\n"+
                    "of tax authorities for registration of taxpayers (СОУН), service territory in\r\n"+
                    "which this is the address object. The length of the code - 4 digits"}
                    ,{Languages.Русский,"\"Код территориального участка ИФНС\" содержит код территориального участка*\r\n"+
                    "(упраздненной инспекции, преобразованной в подразделение межрайонной инспекции:\r\n"+
                    "отдел, территориальный участок и т.п.) ИФНС России по ведомственному справочнику кодов\r\n"+
                    "обозначений налоговых органов для целей учета налогоплательщиков (СОУН), обслуживающего территорию,\r\n"+
                    "на которой расположен данный адресный объект. Длина кода – 4 разряда"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _ocatd_kladr_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"ОКАТО:"}
                    ,{Languages.English,"ОКАТО:"}
                    ,{Languages.Русский,"ОКАТО:"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _ocatd_kladr_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"\"Kode OKATO\" contains the object code of the administrative-territorial\r\n"+
                    "division of All-Russian classifier OKATO appropriate level (from the Russian Federation\r\n"+
                    "subject to the rural village). Code length - 11 bits (fill all 11 digits)"}
                    ,{Languages.English,"\"OKATO Code\" contains the object code of the administrative-territorial\r\n"+
                    "division of All-Russian classifier OKATO appropriate level (on the subject of the\r\n"+
                    "Russian Federation to the rural village). The length of the code - 11 digits"}
                    ,{Languages.Русский,"\"Код ОКАТО\" содержит код объекта административно-территориального\r\n"+
                    "деления по общероссийскому классификатору ОКАТО соответствующего уровня (от субъекта РФ\r\n"+
                    "до сельского населенного пункта). Длина кода – 11 разрядов (заполняются все 11 разрядов)"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _count_elements_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"zählen Elemente im Knoten:"}
                    ,{Languages.English,"count elements in node:"}
                    ,{Languages.Русский,"всего объектов в узле:"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _count_elements_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Die Zahl der Zeilen in der Tabelle (siehe niedriger)\r\n"+
                    "und der Tochterknoten im gewählten Knoten des Klassierers"}
                    ,{Languages.English,"The number of rows in the table (below)\r\n"+
                    "and sub-assemblies in a selected node of the classifier"}
                    ,{Languages.Русский,"Количество строк в таблице (см. ниже)\r\n"+
                    "и дочерних узлов в выбранном узле классификатора"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _time_of_execution_elements_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Die Zeit der Ausführung:"}
                    ,{Languages.English,"time of execution:"}
                    ,{Languages.Русский,"время выполнения:"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _time_of_execution_elements_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Zeit in Millisekunden, dass es das Programm nahm, um den letzten Befehl ausführen.\r\n"+
                    "Diesmal besteht aus der Ausführungszeit einer Datenbank-Abfrage und die benötigte Zeit, um in Form von Daten füllen."}
                    ,{Languages.English,"Time in milliseconds that it took the program to execute the last command.\r\n"+
                    "This time consists of the execution time of a database query and the time it took to fill the form data."}
                    ,{Languages.Русский,"Время в миллисекундах, которое понадобилось программе на выполнение последней команды.\r\n"+
                    "Это время складывается из времени выполнения запроса к базе данных и времени, которое понадобилось для заполнения формы данными."}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _status_label_text
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Abschließen"}
                    ,{Languages.English,"Done"}
                    ,{Languages.Русский,"Готово"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _warning_engin_search_of_close_connect
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Bevor Sie eine Suche starten, um das Datenbank-Programm verbinden"}
                    ,{Languages.English,"Before you run a search, connect to the database program"}
                    ,{Languages.Русский,"Прежде чем запустить поиск, подключитесь к базе данных программы"}
                    }[Global.CurrentLNG];
                    }
                }
            }
            public static string _warning_engin_search_non_connect
            {
                get
                {
                    {
                        return new Dictionary<Languages, string> { 
                    {Languages.Deutsch,"Es gibt keine offenen Datenbank"}
                    ,{Languages.English,"Not connected to database"}
                    ,{Languages.Русский,"Нет открытой базы данных"}
                    }[Global.CurrentLNG];
                    }
                }
            }
        }
    }
}