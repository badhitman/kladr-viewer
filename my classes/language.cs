using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KLADR_viewer_v4.my_classes
{
    static class language
    {
        public static language.languages detectLang(string stringName)
        {
            foreach (language.languages lang in Enum.GetValues(typeof(language.languages)))
            {
                if (lang.ToString() == stringName)
                    return lang;
            }
            return languages.English;
        }

        public enum languages { English, Deutsch, Русский/*, Français*/ };

        public static class other
        {
            public static string _create_connect_to_dbf_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Es schafft eine Verbindung zu DBF"}
                    ,{languages.English,"Create connect to DBF..."}
                    ,{languages.Русский,"Создаётся подключение к DBF"}
                    /*,{languages.Français,"Il crée une connexion à DBF"}*/
                    }[global.currentLNG];
                    }
                }
            }
            public static string _unable_to_connect_to_db
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Kann nicht zur Datenbank verbinden КЛАДР. Убедитесь, что в указанной папке присутствуют файлы КЛАДР\n\n\"KLADR.DBF\"\n\"STREET.DBF\"\n\"DOMA.DBF\"\n\n"}
                    ,{languages.English,"Unable to connect to the database КЛАДР.\nMake sure the specified folder are the files КЛАДР\n\n\"KLADR.DBF\"\n\"STREET.DBF\"\n\"DOMA.DBF\"\n\n"}
                    ,{languages.Русский,"Не удалось подключиться к базе данных КЛАДР.\nУбедитесь, что в указанной папке присутствуют файлы КЛАДР\n\n\"KLADR.DBF\"\n\"STREET.DBF\"\n\"DOMA.DBF\"\n\n"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _error_connect_to_db
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Connection Error!"}
                    ,{languages.English,"Error connecting!"}
                    ,{languages.Русский,"Ошибка подключения!"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _create_connect
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Erstellen Sie eine Verbindung mit dem SQLite..."}
                    ,{languages.English,"Create connect SQLite..."}
                    ,{languages.Русский,"Создаём подключение к SQLite..."}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _transfer_records_socrbase
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Datensätze importieren 'SOCRBASE' DBF->SQLite"}
                    ,{languages.English,"Transfer records 'SOCRBASE' DBF->SQLite"}
                    ,{languages.Русский,"Импорт записей 'SOCRBASE' DBF->SQLite"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _test_correct_dbf_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Prüfung der Richtigkeit DBF"}
                    ,{languages.English,"Testing the correctness DBF..."}
                    ,{languages.Русский,"Тестирование корректности DBF..."}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _transfer_records_kladr
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"übertragen 'KLADR' DBF->SQLite..."}
                    ,{languages.English,"Transfer records 'KLADR' DBF->SQLite..."}
                    ,{languages.Русский,"Перенос 'KLADR' DBF->SQLite..."}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _create_data_base_to_region
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Erstellen einer SQLite-Datenbank für die Region"}
                    ,{languages.English,"Create Data Base's SQLite to region"}
                    ,{languages.Русский,"Создание базы данных SQLite для региона"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _transfer_records_street
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"übertragen 'STREET' DBF->SQLite..."}
                    ,{languages.English,"Transfer records 'STREET' DBF->SQLite..."}
                    ,{languages.Русский,"Перенос 'STREET' DBF->SQLite..."}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _transfer_records_doma
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"übertragen 'DOMA' DBF->SQLite..."}
                    ,{languages.English,"Transfer records 'DOMA' DBF->SQLite..."}
                    ,{languages.Русский,"Перенос 'DOMA' DBF->SQLite..."}
                    }[global.currentLNG];
                }
            }
            public static string _indexing_sqlitq_database_to_region
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Indizierung von SQLite-Datenbank (region"}
                    ,{languages.English,"Indexing SQLite Data Base (region"}
                    ,{languages.Русский,"Индексирование SQLite базы данных (регион"}
                    }[global.currentLNG];
                }
            }
            public static string _create_connect_to_dbf
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Erstellen einer Verbindung zu DBF"}
                    ,{languages.English,"Create connect to DBF..."}
                    ,{languages.Русский,"Создание подключения к DBF"}
                    }[global.currentLNG];
                }
            }
            public static string _connected_to_data_base_of_open
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Verbindung mit der Region"}
                    ,{languages.English,"connected to the base region"}
                    ,{languages.Русский,"подключение к базе региона"}
                    }[global.currentLNG];
                }
            }
        }

        public static class formCreateDB
        {
            public static string _window_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Erstellen einer neuen Datenbank "+global.preficsBildProgramm}
                    ,{languages.English,"Create new data base "+global.preficsBildProgramm}
                    ,{languages.Русский,"Создание новой базы данных "+global.preficsBildProgramm}
                    }[global.currentLNG];
                }
            }
            public static string _label_name_data_base_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Database Name:"}
                    ,{languages.English,"Name database:"}
                    ,{languages.Русский,"Имя базы данных:"}
                    }[global.currentLNG];
                }
            }
            public static string _label_name_data_base_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Der Name der Datenbank (lokale Ordner in Windows)"}
                    ,{languages.English,"The name of the database (including the name of the folder in windows)"}
                    ,{languages.Русский,"Имя базы данных (локальная папка в Windows)"}
                    }[global.currentLNG];
                }
            }
            public static string _folder_GNIVC_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Ordner DB ГНИВЦ"}
                    ,{languages.English,"Folder DB ГНИВЦ:"}
                    ,{languages.Русский,"Папка DB ГНИВЦ"}
                    }[global.currentLNG];
                }
            }
            public static string _folder_GNIVC_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Zusammensetzung und Struktur des Klassifikators\r\n"+
                         "\r\n"+
                    "Auf magnetischen Medien wird ein Klassifikator in den folgenden Formular DBF-Dateien konzipiert:\r\n"+
                    "Datei Kladr.dbf - enthält Datensätze mit den Gegenständen der ersten vier Gliederungsebenen (Regionen, Bezirke (Ulus), die Stadt, Städte, Gemeinderäte, ländliche Gebiete);\r\n"+
                    "Datei Street.dbf - enthält Datensätze mit den Objekten der fünften Ebene der Einstufung (die Straßen der Städte und Gemeinden);\r\n"+
                    "Datei Doma.dbf - enthält Datensätze mit den Objekten der sechsten Ebene der Einstufung (Anzahl der Häuser Straßen der Städte und Gemeinden);\r\n"+
                    "Datei Flat.dbf - enthält Datensätze mit den Objekten der siebten Ebene der Einstufung (Zahl der Wohnungen Häuser);\r\n"+
                    "Datei Socrbase.dbf - enthält Datensätze mit kurzen Namen von Arten von Websites gezielt;\r\n"+
                    "Altnames.dbf-Datei enthält Informationen über die Einhaltung von Datensätzen alten und neuen Namen der Zielobjekte, sowie Informationen über den anvisierten Objekt-Code Compliance vor und nach ihrer Versetzung."}
                    ,{languages.English,"Composition and structure of the classifier\r\n"+
                    "On magnetic media, a classifier is designed in the following form DBF-files:\r\n"+
                    "File Kladr.dbf - contains records with the objects of the first four classification levels (regions, districts (ulus), the city, towns, village councils, rural areas);\r\n"+
                    "File Street.dbf - contains records with the objects of the fifth level of classification (the streets of cities and towns);\r\n"+
                    "File Doma.dbf - contains records with the objects of the sixth level of classification (number of houses streets of cities and towns);\r\n"+
                    "File Flat.dbf - contains records with the objects of the seventh level of classification (number of apartments houses);\r\n"+
                    "File Socrbase.dbf - contains records with short names of types of targeted sites;\r\n"+
                    "Altnames.dbf-file contains information about compliance with codes of records old and new names of targeted objects, as well as information about the targeted object code compliance before and after their reassignment"}
                    ,{languages.Русский,"Состав и структура классификатора\r\n"+
                        "\r\n"+
                    "На магнитных носителях классификатор оформлен в виде следующих DBF-файлов:\r\n"+
                    "файл Kladr.dbf – содержит записи с объектами первых четырех уровней классификации (регионы; районы (улусы); города, поселки городского типа, сельсоветы; сельские населенные пункты);\r\n"+
                    "файл Street.dbf – содержит записи с объектами пятого уровня классификации (улицы городов и населенных пунктов);\r\n"+
                    "файл Doma.dbf – содержит записи с объектами шестого уровня классификации (номера домов улиц городов и населенных пунктов);\r\n"+
                    "файл Flat.dbf  – содержит записи с объектами седьмого уровня классификации (номера квартир домов);\r\n"+
                    "файл Socrbase.dbf – содержит записи с краткими наименованиями типов адресных объектов;\r\n"+
                    "файл Altnames.dbf –содержит сведения о соответствии кодов записей со старыми и новыми наименованиями адресных объектов, а также сведения о соответствии кодов адресных объектов до и после их переподчинения"}
                    }[global.currentLNG];
                }
            }
            public static string _text_box_log_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Progress-Datenbank Import-Programm"}
                    ,{languages.English,"Progress import the database into the program"}
                    ,{languages.Русский,"Прогресс импорта базы данных в программе"}
                    }[global.currentLNG];
                }
            }
            public static string _button_start_transfer
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"starten Sie importieren"}
                    ,{languages.English,"Start transfer"}
                    ,{languages.Русский,"Начать импорт"}
                    }[global.currentLNG];
                }
            }
            public static string _button_close
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Schließen"}
                    ,{languages.English,"Close"}
                    ,{languages.Русский,"Закрыть"}
                    }[global.currentLNG];
                }
            }
        }

        public static class formKLADRtoCSV
        {
            public static string _window_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Konverter/import *. DBF to *. CSV "+global.preficsBildProgramm}
                    ,{languages.English,"converter/import *.DBF to *.CSV "+global.preficsBildProgramm}
                    ,{languages.Русский,"Поиск в классификаторе "+global.preficsBildProgramm}
                    }[global.currentLNG];
                }
            }
            public static string _label_info
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Zum Konvertieren von DBF-Dateien in CSV genug, um die gewünschte Datei und\r\n"+
                    "drücken Sie Import DBF auszuwählen. Import Tool erstellt eine Datei in einem Ordner\r\n"+
                    "mit dem Namen der ursprünglichen Datei, aber mit der Endung CSV. Import Tool wurde\r\n"+
                    "vor allem für KLADR-Viewer erstellt, aber es ist nicht auf diese Dateien beschränkt.\r\n"+
                    "Sie können dieses Tool verwenden, um DBF-Datei ohne Einschränkungen zu\r\n"+
                    "importieren. Die resultierende Datei ist eine gültige CSV-Datei und kann verwendet\r\n"+
                    "werden, zu importieren/exportieren (zB Import in MySQL, über phpMyAdmin, etc.)\r\n"+
                    "und für andere Zwecke sein."}
                    ,{languages.English,"To convert a DBF file in CSV enough to select the desired DBF file and click\r\n"+
                    "Import. Import Tool creates a file in a folder titled with the original file, but\r\n"+
                    "with the extension CSV. Import Tool was created primarily for the viewer of\r\n"+
                    "the classifier, but it is not limited only to these files. You can use this tool to\r\n"+
                    "import a DBF file without any restrictions. The resulting file is a valid CSV file\r\n"+
                    "and can easily be used in the import / export such as MySQL (for example\r\n"+
                    "through PHPMyAdmin, etc.) and any other needs."}
                    ,{languages.Русский,"Чтобы преобразовать DBF файлы в CSV достаточно выбрать нужный файл DBF\r\n"+
                    "и нажать Импорт. Инструмент импорта создает одноимённый файл в папке\r\n"+
                    "оригинального файла, но с расширением CSV. Инструмент импорта был создан\r\n"+
                    "в первую очередь для КЛАДР-Viewer, но он не ограничивается только этими\r\n"+
                    "файлами. Вы можете использовать этот инструмент для импорта DBF файлов\r\n"+
                    "без каких-либо ограничений. Полученный файл является валидным CSV файлом\r\n"+
                    "и может быть использован в импорте/экспорте (например\r\n"+
                    "импорт в MySQL, через PHPMyAdmin, и т.д.) и для любых других нужд."}
                    }[global.currentLNG];
                }
            }
            public static string _button_import_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Importe"}
                    ,{languages.English,"Import"}
                    ,{languages.Русский,"Импорт"}
                    }[global.currentLNG];
                }
            }
            public static string _button_close_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Schließen"}
                    ,{languages.English,"Close"}
                    ,{languages.Русский,"Закрыть"}
                    }[global.currentLNG];
                }
            }
        }

        public static class formSearch
        {
            public static string _window_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Suchen Sie in Klassifikator "+global.preficsBildProgramm}
                    ,{languages.English,"Search in Classifier "+global.preficsBildProgramm}
                    ,{languages.Русский,"Поиск в классификаторе "+global.preficsBildProgramm}
                    }[global.currentLNG];
                }
            }
            public static string _label_qoery_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Abfrage:"}
                    ,{languages.English,"Query:"}
                    ,{languages.Русский,"Запрос:"}
                    }[global.currentLNG];
                }
            }
            public static string _label_qoery_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"In der Standardeinstellung ist die Suche Groß-und Kleinschreibung, aber es ist möglich die Suche mit T-SQL-Ausdrucks-und Groß-und Kleinschreibung\r\n"+
                        "(Sie setzen den Ausdruck in geschweiften Klammern {}. Beispiel {meineSuchanfrageStadt___%})"}
                    ,{languages.English,"By default the search is case insensitive, but it is possible to search using T-SQL expression and case sensitive\r\n"+
                    "(you put the expression in curly braces {}. Example {mySearchQueryCity___%})"}
                    ,{languages.Русский,"По умолчанию поиск не чувствителен к регистру, но можно искать с помощью T-SQL выражений, и/или с учётом регистра\r\n"+
                         "(поместите ваше выражение в фигурные скобки {}. Пример {мойПоисковыйЗапросГорода___%})"}
                    }[global.currentLNG];
                }
            }
            public static string _button_start_search_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Suche"}
                    ,{languages.English,"Search"}
                    ,{languages.Русский,"Поиск"}
                    }[global.currentLNG];
                }
            }
            public static string _button_start_search_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Suche starten"}
                    ,{languages.English,"Starting search"}
                    ,{languages.Русский,"Начать поиск"}
                    }[global.currentLNG];
                }
            }
            public static string _where_look_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Ausgewählte Bereiche der Suche. Wählen Sie alle oder einige der gewünschten Bereichen.\r\n"+
                        "Je kleiner die gewählte Regionen der schnelleren Suche ist vorbei"}
                    ,{languages.English,"Selected regions of the search. Select all or desired regions.\r\n"+
                    "The smaller the selected regions of the faster search"}
                    ,{languages.Русский,"Выбранные регионы поиска. Выбрать все или несколько желаемых регионов.\r\n"+
                         "Чем меньше выбрано регионов тем быстрее закончится поиск"}
                    }[global.currentLNG];
                }
            }
            public static string _where_look_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"wo sie suchen?"}
                    ,{languages.English,"where to look?"}
                    ,{languages.Русский,"где искать?"}
                    }[global.currentLNG];
                }
            }
            public static string _deselect_all_items_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Deaktivieren Sie alle"}
                    ,{languages.English,"Unselect all regions"}
                    ,{languages.Русский,"Снять выделение везде"}
                    }[global.currentLNG];
                }
            }
            public static string _invert_select_items_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Auswahl umkehren"}
                    ,{languages.English,"Invert select regions"}
                    ,{languages.Русский,"Инвертировать выделение"}
                    }[global.currentLNG];
                }
            }
            public static string _select_all_items_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Wählen Sie alle"}
                    ,{languages.English,"Select all regions"}
                    ,{languages.Русский,"Выбрать все"}
                    }[global.currentLNG];
                }
            }
            public static string _grid_view_result_search_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Diese Suchergebnisse"}
                    ,{languages.English,"Result data of search"}
                    ,{languages.Русский,"Данные результата поиска"}
                    }[global.currentLNG];
                }
            }
            public static string _search_in
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Suche in der"}
                    ,{languages.English,"search in"}
                    ,{languages.Русский,"поиск в"}
                    }[global.currentLNG];
                }
            }
            public static string _search_of
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch," von "}
                    ,{languages.English," of "}
                    ,{languages.Русский," из "}
                    }[global.currentLNG];
                }
            }
        }

        public static class formSettings
        {
            public static string _title_window
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Einstellungen "+global.preficsBildProgramm}
                    ,{languages.English,"Settings "+global.preficsBildProgramm}
                    ,{languages.Русский,"Настройки "+global.preficsBildProgramm}
                    }[global.currentLNG];
                }
            }
            public static string _lang_app_groupbox_tex
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Die Sprache des Programms"}
                    ,{languages.English,"Language of application"}
                    ,{languages.Русский,"Выберите язык для программы"}
                    }[global.currentLNG];
                }
            }
            public static string _chose_lang_programm_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Wählen Sie die bevorzugte Sprache für das Programm"}
                    ,{languages.English,"Please choose the preferred language for the program"}
                    ,{languages.Русский,"Выберите нужный язык для программы"}
                    }[global.currentLNG];
                }
            }
            public static string _group_box_time_aut_cash
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Timeout-Caching"}
                    ,{languages.English,"Engine cache timeout"}
                    ,{languages.Русский,"Таймаут механизма кэширования"}
                    }[global.currentLNG];
                }
            }
            public static string _label_time_aut_cash
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Das Timeout der Abfrage an die Datenbank Auswahl eines Knotens im Baum KLADR.Wenn der Wahl einiger\r\n" +
                     "Knoten im Baum dauert länger KLADR ausgewählte Wert (zB 150 Millisekunden mehr), dann die Wahl wird\r\n" +
                     " zwischengespeichert und anschließende Gespräche werden aus dem Ergebnis-Cache genommen werden"}
                    ,{languages.English,"The timeout of the query to the database selection of a node in the tree KLADR. If the\r\n"+
                    "choice of some nodes in the tree takes longer KLADR selected value (eg 150 milliseconds\r\n"+
                    "longer), then the choice will be cached and subsequent calls will be taken from the result cache"}
                    ,{languages.Русский,"Тайм-аут запроса к базе данных Выбора узла в дереве КЛАДР. Если выбор некоторых\r\n" +
                     " узлов в дереве занимает много времени (например, более 150 миллисекунд), то результат\r\n" +
                     " выбора будет смохранён в кэше и последующие вызовы будут взяты из кэша результатов"}
                    }[global.currentLNG];
                }
            }
            public static string _label_ms_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"millisekunden"}
                    ,{languages.English,"milliseconds"}
                    ,{languages.Русский,"миллисекунд"}
                    }[global.currentLNG];
                }
            }
            public static string _group_box_folder_database_program
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Ordner-Datenbank-Programm"}
                    ,{languages.English,"Folder database program"}
                    ,{languages.Русский,"Папка базы данных программы"}
                    }[global.currentLNG];
                }
            }
            public static string _label_folder_database_program_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Geben Sie den Ordner, wo das Programm seine Daten gespeichert werden. Sie können einen beliebigen\r\n"+
                     "Ordner auf Ihrem PC oder Ordners im Netzwerk. Standardmäßig werden die Dokumente\r\n" +
                     "\"KLADR-Viewer\"-Ordner Ihres Benutzer-Verzeichnis wird erstellt und es wird ein Ordner erstellt Datenbanken"}
                    ,{languages.English,"Specify the folder where the program will store its data KLADR. You can specify any folder\r\n"+
                    "on your PC or netbios address of the folder on the network. By default, the documents\r\n"+
                    "folder of your user directory is created \"KLADR-Viewer\" and it creates a folder databases"}
                    ,{languages.Русский,"Укажите папку, в которой программа будет хранить свои данные КЛАДР. Можно указать любую\r\n"+
                     "папку на компьютере или папку в сети. По умолчанию в папке документовпользователя\r\n" +
                     "создается каталог \"КЛАДР-Viewer \", и уже в этой папке созлаются каталоги с базами данных"}
                    }[global.currentLNG];
                }
            }
            public static string _button_reset_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Auf Standard zurücksetzen"}
                    ,{languages.English,"Reset to Defaults"}
                    ,{languages.Русский,"Сброс на стандартные"}
                    }[global.currentLNG];
                }
            }
        }

        public static class formStart
        {
            static public string _file_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Datei"}
                    ,{languages.English,"File"}
                    ,{languages.Русский,"Файл"}
                    }[global.currentLNG];
                }
            }
            public static string _file_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Datei"}
                    ,{languages.English,"File"}
                    ,{languages.Русский,"Файл"}
                    }[global.currentLNG];
                }

            }
            static public string _create_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Erstellen"}
                    ,{languages.English,"Create"}
                    ,{languages.Русский,"Создать"}
                    }[global.currentLNG];
                }
            }
            public static string _create_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Erstellen Sie eine neue Datenbank aus dem Daten KLADR ГНИВЦ"}
                    ,{languages.English,"Create a new database from the base classifier"}
                    ,{languages.Русский,"Создать новую базу данных из данных КЛАДР ГНИВЦ"}
                    }[global.currentLNG];
                }
            }
            static public string _open_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Öffnen"}
                    ,{languages.English,"Open"}
                    ,{languages.Русский,"Открыть"}
                    }[global.currentLNG];
                }
            }
            public static string _open_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Öffnen Sie die Datenbank"}
                    ,{languages.English,"Open the database"}
                    ,{languages.Русский,"Открыть базу данных"}
                    }[global.currentLNG];
                }
            }
            static public string _exit_text
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Ausgang"}
                    ,{languages.English,"Exit"}
                    ,{languages.Русский,"Выход"}
                    }[global.currentLNG];
                }
            }
            public static string _exit_tool_tip
            {
                get
                {
                    return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Schließen Sie das Programm"}
                    ,{languages.English,"Close the program"}
                    ,{languages.Русский,"Закрыть программу"}
                    }[global.currentLNG];
                }
            }
            public static string _service_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Service"}
                    ,{languages.English,"Service"}
                    ,{languages.Русский,"Сервис"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _service_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Service"}
                    ,{languages.English,"Service"}
                    ,{languages.Русский,"Сервис"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _search_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Suche"}
                    ,{languages.English,"Search"}
                    ,{languages.Русский,"Поиск"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _search_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Suchen Sie nach Titeln in der Datenbank"}
                    ,{languages.English,"Find items in the database"}
                    ,{languages.Русский,"Поиск элементов по базе данных"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _dbf_to_csv_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"KL&ADR im &CSV"}
                    ,{languages.English,"KL&ADR to &CSV"}
                    ,{languages.Русский,"KL&ADR в &CSV"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _dbf_to_csv_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Convert DBF-Dateien im CSV-Format"}
                    ,{languages.English,"Convert DBF files to CSV format"}
                    ,{languages.Русский,"Конвертировать DBF файлы в формат CSV"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _settings_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Einstellungen"}
                    ,{languages.English,"Settings"}
                    ,{languages.Русский,"Настройки"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _settings_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Programm-Einstellungen"}
                    ,{languages.English,"Programm settings"}
                    ,{languages.Русский,"Настройки программы"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _textWindow
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Russland Classifier von mail-Adressen "+global.preficsBildProgramm}
                    ,{languages.English,"Russia Classifier of mail addresses "+global.preficsBildProgramm}
                    ,{languages.Русский,"Классификатор почтовых адресов РФ "+global.preficsBildProgramm}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _help_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Auskunft"}
                    ,{languages.English,"Help"}
                    ,{languages.Русский,"Справка"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _help_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Die Auskunft über das Programm"}
                    ,{languages.English,"Help programm"}
                    ,{languages.Русский,"Справка по программе"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _desc_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Beschreibung"}
                    ,{languages.English,"Description"}
                    ,{languages.Русский,"Описание"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _desc_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Beschreibung"}
                    ,{languages.English,"Description"}
                    ,{languages.Русский,"Описание"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _about_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Über das Programm"}
                    ,{languages.English,"About the program"}
                    ,{languages.Русский,"О программе"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _about_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Über das Programm"}
                    ,{languages.English,"About the program"}
                    ,{languages.Русский,"О программе"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _tree_start_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Das Objekt Baum Klassifikator"}
                    ,{languages.English,"The object tree classifier address"}
                    ,{languages.Русский,"Дерево объектов классификатора"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _data_grid_view_detail_start_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Die Gegenstände der Sichter-Adressen sind in den ausgewählten Knoten des Baumes Klassifikator\r\n"}
                    ,{languages.English,"Objects of address classifier embedded in the selected node from the tree classifier\r\n(table rows are grouped by type of facility and highlighted different background)"}
                    ,{languages.Русский,"Объекты классификатора адресов находящиеся в выбранном узле из дерева классификатора\n\r(Zeilen werden nach der Art der Anlage gruppiert und hob die verschiedenen Hintergrund)"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _name_title_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Namen der Anlage:"}
                    ,{languages.English,"Name of the object:"}
                    ,{languages.Русский,"Наименование:"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _name_title_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"\"Der Name des Objekts \"enthält die Namen der gezielten Ebenen der Klassifikation von Objekten 4.1. Länge des Namens darf maximal 40 Zeichen\r\n\r\n" +
                    "\"Kurzname des Objekttyps \"enthält den abgekürzten Namen der Adresse des Objekts 1 -. 4 Ebenen der Klassifikation \r\n" +
                    "Die Länge dieser Name sollte nicht länger als 10 Zeichen Werte Akronym Art der Adresse des Objekts 1 -. 4 Ebenen der Klassifikation sind \r\n" +
                    "In Anlage 1 zu der Beschreibung des Qualifier befasst sich mit der Russischen Föderation (KLADR)"}
                    ,{languages.English,"\"Project Name\" contains the names of the objects targeted 4.1 classification levels. The length of the name must not exceed 40 characters\r\n\r\n"+
                    "\"Abbreviated name of the object type\" contains the abbreviated name of the address type of the object 1 - 4 levels of classification.\r\n"+
                    "The length of this name should not exceed 10 characters. Valid values ​​acronym type the address of the object 1 - 4 levels of classification are presented\r\n"+
                    "in Appendix 1 to the description of the qualifier addresses the Russian Federation (KLADR)"}
                    ,{languages.Русский,"\"Наименование объекта\" содержит наименования адресных объектов 1-4 уровней классификации. Длина наименования не должна превышать 40 символов\r\n\r\n"+
                     "\"Сокращенное наименование типа объекта\" содержит сокращённое наименование типа адресного объекта 1 – 4 уровня классификации.\r\n"+
                    "Длина этого наименования не должна превышать 10 символов. Допустимые значения сокращенного наименования типа адресного объекта 1 – 4 уровня классификации представлены\r\n"+
                    "в Приложении 1 к Описанию классификатора адресов Российской Федерации (КЛАДР)"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _code_kladr_tool_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Kode im КЛАДР:"}
                    ,{languages.English,"Code of КЛАДР:"}
                    ,{languages.Русский,"Код в КЛАДР:"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _code_kladr_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"\"Der Kode\" nimmt den Identifizierungskode des Adressobjektes 1 – 4 Niveaus der Klassifikation und das Merkmal seiner Aktualität auf.\r\n"+
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
                    ,{languages.English,"\"Code\" includes an identification code of the targeted object 1 - 4 levels of classification and a sign of its relevance.\r\n"+
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
                    ,{languages.Русский,"\"Код\" включает идентификационный код адресного объекта 1 – 4 уровня классификации и признак его актуальности.\r\n"+
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
                    }[global.currentLNG];
                    }
                }
            }
            public static string _priznak_aktualnosti_00
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Tatsächliches Objekt (seinen Namen, Unterordnung entsprechen dem Stand zum Zeitpunkt des Adressenraums)"}
                    ,{languages.English,"Actual object (its name, subordination correspond to the state at the moment of the address space)"}
                    ,{languages.Русский,"Актуальный объект (его наименование, подчиненность соответствуют состоянию на данный момент адресного пространства)"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _priznak_aktualnosti_01_50
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Das Objekt wurde in diesem Eintrag umbenannt wird einer seiner früheren Namen (aktuelle Adresse Objekt in der Datenbank mit dem gleichen Code vorhanden, aber mit einem Schild Bedeutung “00” gegeben"}
                    ,{languages.English,"The object has been renamed in this entry is given one of his former names (current address object is present in the database with the same code, but with a sign relevance “00”"}
                    ,{languages.Русский,"Объект был переименован, в данной записи приведено одно из прежних его наименований (актуальный адресный объект присутствует в базе данных с тем же кодом, но с признаком актуальности “00”"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _priznak_aktualnosti_51
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Das Objekt zugewiesen oder in dem anderen Objekt verbunden (Objekt-to-date-Adresse ist auf der Grundlage Altnames.dbf bestimmt) wurde"}
                    ,{languages.English,"The object was reassigned or joined in the other object (object-to-date address is determined based on Altnames.dbf)"}
                    ,{languages.Русский,"Объект был переподчинен или влился в состав другого объекта (актуальный адресный объект определяется по базе Altnames.dbf)"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _priznak_aktualnosti_52_98
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Backup-Funktion Wert Bedeutung"}
                    ,{languages.English,"Backup feature value relevance"}
                    ,{languages.Русский,"Резервные значения признака актуальности"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _priznak_aktualnosti_99
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Addressable-Objekt nicht vorhanden, das heißt keine entsprechende tatsächliche Adresse des Objekts"}
                    ,{languages.English,"Addressable object does not exist, i.e. no corresponding actual address of the object"}
                    ,{languages.Русский,"Адресный объект не существует, т.е. нет соответствующего ему актуального адресного объекта"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _index_kladr_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Postleitzahl:"}
                    ,{languages.English,"Postal index:"}
                    ,{languages.Русский,"Почтовый индекс:"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _index_kladr_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"\"Die Postleitzahl\" enthält die Postleitzahl des Unternehmens der postalischen Verbindung,\r\n"+
                    "das das vorliegende Adressobjekt bedient. Die Länge der Postleitzahl – 6 Kategorien"}
                    ,{languages.English,"\"Zip code\" contains the postal code Company postal\r\n"+
                    "service address this subject. The length zip - 6 digits"}
                    ,{languages.Русский,"\"Почтовый индекс\" содержит почтовый индекс предприятия почтовой связи,\r\n"+
                    "обслуживающего данный адресный объект. Длина почтового индекса – 6 разрядов"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _gninmb_kladr_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Kode ИФНС:"}
                    ,{languages.English,"Code ИФНС:"}
                    ,{languages.Русский,"Код ИФНС:"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _gninmb_kladr_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"\"Kode ИФНС\" contains the code inspectorate of federal agency of federal tax service of Russia classifier \"notation of the tax\r\n"+
                    "bodies\" (SONO), serving the territory, on which is located the address object. The code length - 4 digits"}
                    ,{languages.English,"\"ИФНС Code\" contains the code for the Russian Federal Tax Service Inspectorate departmental FTS Russia Classifier \"The notation\r\n"+
                    "of the tax authorities\" (СОНО), the serving area, which is currently targeted object. The length of the code - 4 digits"}
                    ,{languages.Русский,"\"Код ИФНС\" содержит код инспекции ФНС России по ведомственному ФНС России классификатору \"Система обозначений\r\n"+
                    "налоговых органов\" (СОНО), обслуживающей территорию, на которой расположен данный адресный объект. Длина кода – 4 разряда"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _uno_kladr_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Land ИФНС:"}
                    ,{languages.English,"Land ИФНС:"}
                    ,{languages.Русский,"Участок ИФНС:"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _uno_kladr_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"\"Code der territoriale Bereich ИФНС\" beinhaltet die territoriale Vorwahl *\r\n"+
                    "(abgeschafft Inspektion in die Einheit kreisübergreifenden Inspektorat umgewandelt:\r\n"+
                    "Front, den territorialen Bereich, etc.) ИФНС Russland auf Abteilungsebene Handbuch Codes\r\n"+
                    "der Steuerbehörden für die Zwecke des Steuerpflichtigen (СОУН), Service-Bereich , der derzeit\r\n"+
                    "Gegenstand ausgerichtet. Die Länge der Code - 4-stellig"}
                    ,{languages.English,"\"Code of the territorial area ИФНС\" includes the territorial area code *\r\n"+
                    "(abolished inspection, transformed into a unit of inter-district inspectorate:\r\n"+
                    "Front, the territorial area, etc.) ИФНС Russia on a departmental directory, codes\r\n"+
                    "of tax authorities for registration of taxpayers (СОУН), service territory in\r\n"+
                    "which this is the address object. The length of the code - 4 digits"}
                    ,{languages.Русский,"\"Код территориального участка ИФНС\" содержит код территориального участка*\r\n"+
                    "(упраздненной инспекции, преобразованной в подразделение межрайонной инспекции:\r\n"+
                    "отдел, территориальный участок и т.п.) ИФНС России по ведомственному справочнику кодов\r\n"+
                    "обозначений налоговых органов для целей учета налогоплательщиков (СОУН), обслуживающего территорию,\r\n"+
                    "на которой расположен данный адресный объект. Длина кода – 4 разряда"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _ocatd_kladr_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"ОКАТО:"}
                    ,{languages.English,"ОКАТО:"}
                    ,{languages.Русский,"ОКАТО:"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _ocatd_kladr_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"\"Kode OKATO\" contains the object code of the administrative-territorial\r\n"+
                    "division of All-Russian classifier OKATO appropriate level (from the Russian Federation\r\n"+
                    "subject to the rural village). Code length - 11 bits (fill all 11 digits)"}
                    ,{languages.English,"\"OKATO Code\" contains the object code of the administrative-territorial\r\n"+
                    "division of All-Russian classifier OKATO appropriate level (on the subject of the\r\n"+
                    "Russian Federation to the rural village). The length of the code - 11 digits"}
                    ,{languages.Русский,"\"Код ОКАТО\" содержит код объекта административно-территориального\r\n"+
                    "деления по общероссийскому классификатору ОКАТО соответствующего уровня (от субъекта РФ\r\n"+
                    "до сельского населенного пункта). Длина кода – 11 разрядов (заполняются все 11 разрядов)"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _count_elements_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"zählen Elemente im Knoten:"}
                    ,{languages.English,"count elements in node:"}
                    ,{languages.Русский,"всего объектов в узле:"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _count_elements_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Die Zahl der Zeilen in der Tabelle (siehe niedriger)\r\n"+
                    "und der Tochterknoten im gewählten Knoten des Klassierers"}
                    ,{languages.English,"The number of rows in the table (below)\r\n"+
                    "and sub-assemblies in a selected node of the classifier"}
                    ,{languages.Русский,"Количество строк в таблице (см. ниже)\r\n"+
                    "и дочерних узлов в выбранном узле классификатора"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _time_of_execution_elements_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Die Zeit der Ausführung:"}
                    ,{languages.English,"time of execution:"}
                    ,{languages.Русский,"время выполнения:"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _time_of_execution_elements_tool_tip
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Zeit in Millisekunden, dass es das Programm nahm, um den letzten Befehl ausführen.\r\n"+
                    "Diesmal besteht aus der Ausführungszeit einer Datenbank-Abfrage und die benötigte Zeit, um in Form von Daten füllen."}
                    ,{languages.English,"Time in milliseconds that it took the program to execute the last command.\r\n"+
                    "This time consists of the execution time of a database query and the time it took to fill the form data."}
                    ,{languages.Русский,"Время в миллисекундах, которое понадобилось программе на выполнение последней команды.\r\n"+
                    "Это время складывается из времени выполнения запроса к базе данных и времени, которое понадобилось для заполнения формы данными."}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _status_label_text
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Abschließen"}
                    ,{languages.English,"Done"}
                    ,{languages.Русский,"Готово"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _warning_engin_search_of_close_connect
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Bevor Sie eine Suche starten, um das Datenbank-Programm verbinden"}
                    ,{languages.English,"Before you run a search, connect to the database program"}
                    ,{languages.Русский,"Прежде чем запустить поиск, подключитесь к базе данных программы"}
                    }[global.currentLNG];
                    }
                }
            }
            public static string _warning_engin_search_non_connect
            {
                get
                {
                    {
                        return new Dictionary<languages, string> { 
                    {languages.Deutsch,"Es gibt keine offenen Datenbank"}
                    ,{languages.English,"Not connected to database"}
                    ,{languages.Русский,"Нет открытой базы данных"}
                    }[global.currentLNG];
                    }
                }
            }
        }
    }
}