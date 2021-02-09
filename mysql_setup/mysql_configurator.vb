Imports MySql.Data
Module mysql_configurator
    Sub Main()
        Dim address As String
        Dim user As String
        Dim pass As String
        Dim port As String
        Dim name As String
        Console.WriteLine("Not pro LGBT.")
        System.Threading.Thread.Sleep(200)
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("_________                       __   .____    ._____.    ")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine("\_   ___ \____________    ____ |  | _|    |   |__\_ |__  ")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("/    \  \/\_  __ \__  \ _/ ___\|  |/ /    |   |  || __ \ ")
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("\     \____|  | \// __ \\  \___|    <|    |___|  || \_\ \")
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine(" \______  /|__|  (____  /\___  >__|_ \_______ \__||___  /")
        Console.ForegroundColor = ConsoleColor.DarkCyan
        Console.WriteLine("        \/            \/     \/     \/       \/       \/ ")
        Console.ResetColor()
        Console.BackgroundColor = ConsoleColor.Red
        Console.WriteLine("WARNING: If you are not using this software with a fresh created database, you shoudn't take the risk and do a full database backup.")
        Console.WriteLine("Please read this carefully before proceeding: https://jpn.gitbook.io/cracklib/mysql-setup/requirements")
        Console.ResetColor()
        Console.WriteLine("This interactive wizard will create for you, the administrator, all the necessary tables and columns, also create the admin account.")
retry:  Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.Write("Type in the MySQL server address (default = localhost): ")
        Console.ResetColor()
        address = Console.ReadLine
        If address = "" Then
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("No value provided, assuming the host is 'localhost'.")
            Console.ResetColor()
            address = "localhost"
        End If
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.Write("Type in the database user (default = root): ")
        Console.ResetColor()
        user = Console.ReadLine
        If user = "" Then
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("No value provided, assuming the user is 'root'.")
            Console.ResetColor()
            user = "root"
        End If
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.Write("Type in the user's password (default = NONE): ")
        Console.ResetColor()
        pass = Console.ReadLine
        If pass = "" Then
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("No value provided, assuming the password is blank.")
            Console.ResetColor()
            pass = ""
        End If
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.Write("Type in the database port (default = 3306): ")
        Console.ResetColor()
        port = Console.ReadLine
        If port = "" Then
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("No value provided, assuming the database's port is 3306.")
            Console.ResetColor()
            port = "3306"
        End If
rr:     Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.Write("Type in the database name: ")
        Console.ResetColor()
        name = Console.ReadLine
        If name = "" Then
            Console.ForegroundColor = ConsoleColor.Red
            Console.Beep()
            Console.WriteLine("THIS FIELD CAN'T BE BLANK! PLEASE TRY AGAIN!")
            Console.ResetColor()
            GoTo rr
        End If
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.WriteLine("Database configuration complete!")
        Console.ResetColor()
        Console.WriteLine("-------- TESTS --------")
        Console.Write("Testing MySQL connection... ")
        Dim c As New MySql.Data.MySqlClient.MySqlConnection
        Try
            c.ConnectionString = "datasource=" + address + ";port=" + port + ";username=" + user + ";password=" + pass + ";database=" + name
            c.Open()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("OK!")
            Console.ResetColor()
            Console.WriteLine("-----------------------")
            Console.Beep()
            c.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("FAIL!")
            Console.Beep()
            Console.ResetColor()
            Console.WriteLine(" - Check error below.")
            Console.WriteLine("-----------------------")
            Console.WriteLine(ex.Message)
            Console.Write("Do you want to try again? (Y/N): ")
            If Console.ReadLine = "Y" Then
                GoTo retry
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.Beep()
                Console.WriteLine("Program ended with an error.")
                Console.Read()
                Environment.Exit(1)
            End If
        End Try
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("-------- ADMIN ACCOUNT SETUP --------")
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.Write("Type in the admin username (default = admin): ")
        Console.ResetColor()
        Dim adminuser As String = Console.ReadLine
        If adminuser = "" Then
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("No value provided, assuming the admin's username is 'admin'.")
            Console.ResetColor()
            adminuser = "admin"
        End If
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.Write("Type in the admin password (default = admin123): ")
        Console.ResetColor()
        Dim adminpassword As String = Console.ReadLine
        If adminpassword = "" Then
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("No value provided, assuming the admin's password is 'admin123'.")
            Console.ResetColor()
            adminpassword = "admin123"
        End If
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine("Admin credentials successfully setted up.")
        Console.ResetColor()
        Console.WriteLine("--------- SETTING UP THE DATABASE ---------")
        Console.Write("Connecting to the database... ")
        Console.ForegroundColor = ConsoleColor.Green
        c.ConnectionString = "datasource=" + address + ";port=" + port + ";username=" + user + ";password=" + pass + ";database=" + name
        c.Open()
        Console.WriteLine("OK!")
        Console.Beep()
        Console.ResetColor()
        Console.Write("Dropping existing tables... ")
        Try
            Dim table As String = "DROP TABLES `users`;"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand(table, c)
            command.ExecuteNonQuery()
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write("Table 1 - OK!, ")
            Console.Beep()
            Console.ResetColor()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Table 1 - FAIL!, ")
            Console.Beep()
            Console.ResetColor()
            Console.WriteLine(ex)
        End Try
        Try
            Dim table As String = "DROP TABLES `posts`;"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand(table, c)
            command.ExecuteNonQuery()
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write("Table 2 - OK!, ")
            Console.Beep()
            Console.ResetColor()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("Table 2 - FAIL!, ")
            Console.Beep()
            Console.ResetColor()
            Console.WriteLine(ex)
        End Try
        Try
            Dim table As String = "DROP TABLES `admins`;"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand(table, c)
            command.ExecuteNonQuery()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Table 3 - OK!")
            Console.ResetColor()
            Console.Read()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Table 3 - FAIL!")
            Console.Beep()
            Console.ResetColor()
            Console.WriteLine(ex)
        End Try
        Console.Write("Creating users table... ")
        Try
            Dim table As String = "CREATE TABLE `users` ( `user_id` INT(5) AUTO_INCREMENT , `username` VARCHAR(15) NOT NULL , `password` VARCHAR(50) NOT NULL , `email` VARCHAR(20) NOT NULL , `full_name` TEXT NOT NULL , `image_url` TEXT NULL DEFAULT NULL , `posts_count` INT(3) NULL DEFAULT NULL , `likes_count` INT NOT NULL , `dislikes_count` INT NOT NULL , `creation_date` INT(10) NOT NULL , `banned` TINYINT NULL DEFAULT NULL , PRIMARY KEY (`user_id`)) ENGINE = InnoDB;"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand(table, c)
            command.ExecuteNonQuery()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("OK!")
            Console.Beep()
            Console.ResetColor()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("FAIL!")
            Console.Beep()
            Console.ResetColor()
            Console.WriteLine(" - Check error below.")
            Console.WriteLine("-------------------------------------------")
            Console.WriteLine(ex)
            Console.Read()
            Environment.Exit(1)
        End Try
        System.Threading.Thread.Sleep(1500)
        Console.Write("Creating posts table... ")
        Try
            Dim table As String = "CREATE TABLE `posts` ( `title` VARCHAR(100) NOT NULL , `description` TEXT NOT NULL , `video_url` TEXT NULL DEFAULT NULL , `author_id` INT(5) NOT NULL , `icon_url` TEXT NOT NULL , `download_link` TEXT NOT NULL , `likes` INT NOT NULL , `dislikes` INT NOT NULL ) ENGINE = InnoDB;"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("OK!")
            Console.Beep()
            Console.ResetColor()
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("FAIL!")
            Console.Beep()
            Console.ResetColor()
            Console.WriteLine(" - Check error below.")
            Console.WriteLine("-------------------------------------------")
            Console.WriteLine(ex)
            Console.Read()
            Environment.Exit(1)
        End Try
        System.Threading.Thread.Sleep(1500)
        Console.Write("Creating admins table... ")
        Try
            Dim table As String = "CREATE TABLE `admins` ( `admin_id` VARCHAR(2) NOT NULL , `user_id` INT(5) ) ENGINE = InnoDB;"
            Dim command As New MySql.Data.MySqlClient.MySqlCommand()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("OK!")
            Console.Beep()
            Console.ResetColor()
            Console.Read()
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("FAIL!")
            Console.Beep()
            Console.ResetColor()
            Console.WriteLine(" - Check error below.")
            Console.WriteLine("-------------------------------------------")
            Console.WriteLine(ex)
            Console.Read()
            Environment.Exit(1)
        End Try
        System.Threading.Thread.Sleep(1500)
    End Sub

End Module
