# ConnectionCheckerConsoleApp

.NET Core 3.1

Visual Studio 2022

Реализация приложения проверки доступности сайтов и серверов баз данных.

При начальном запуске приложение проверяет было ли запущено это приложение  с параметрами или без. Если приложение запущено с параметрами (любыми), то сразу же пытается отобразить  результат последней проверки из ранее сохраненного файла(файл в корне приложения CheckResult.json). 

Если приложение было запущено без параметров, то происходят асинхронные проверки доступности всех серверов бд (по строке подключения) и всех сайтов(по адресу), указанных в файле appsettings.json («WebsiteAddresses», «DBAdreses»).

Сайт считается доступным, если в отведенное для запроса время он вернул HttpStatusCode.OK.
Для баз данных аналогичная проверка производится по возможности открытия подключения.

После проверки формируется файл json с результатами, и асинхронно рассылается в виде приложения к письму по указанным в appsettings.json email адресам. Копия файла сохраняется в корне приложения. 

Чтобы изменить или добавить новые адреса сайтов, серверов БД, или адресов доставки результатов, требуется внести соответствующие  изменения в файл appsettings.json, хранящийся в корне приложения(после сборки).

Также добавлен  NLog  для отслеживания ряда действий и ошибок в приложения.
