Imports System.IO
Module Program

    Dim filePath As String = "StudentRecords.txt"

    Sub Main()

        Dim choice As Integer

        Do
            Console.Clear()

            Console.WriteLine("====================================")
            Console.WriteLine("   STUDENT RECORDS MANAGEMENT SYSTEM")
            Console.WriteLine("====================================")
            Console.WriteLine("1. Enter Student Details")
            Console.WriteLine("2. Display Student Records")
            Console.WriteLine("3. Exit")
            Console.WriteLine("====================================")
            Console.Write("Enter your choice: ")

            If Integer.TryParse(Console.ReadLine(), choice) Then

                Select Case choice

                    Case 1
                        EnterStudentDetails()

                    Case 2
                        DisplayStudentRecords()

                    Case 3
                        Console.WriteLine("Thank you for using the system!")

                    Case Else
                        Console.WriteLine("Invalid choice!")

                End Select

            Else
                Console.WriteLine("Please enter a valid number.")
            End If

            If choice <> 3 Then
                Console.WriteLine()
                Console.WriteLine("Press any key to continue pliz...")
                Console.ReadKey()
            End If

        Loop While choice <> 3

    End Sub

    Sub EnterStudentDetails()

        Try
            Console.WriteLine()
            Console.WriteLine("--- ENTER STUDENT DETAILS ---")

            Console.Write("Registration Number: ")
            Dim regNo As String = Console.ReadLine()

            Console.Write("Student Name: ")
            Dim name As String = Console.ReadLine()

            Console.Write("Marks: ")
            Dim marks As Double

            If String.IsNullOrWhiteSpace(regNo) OrElse
               String.IsNullOrWhiteSpace(name) Then

                Console.WriteLine("Registration number and name are required.")
                Return
            End If

            If Not Double.TryParse(Console.ReadLine(), marks) OrElse
               marks < 0 OrElse marks > 100 Then

                Console.WriteLine("Please enter valid marks between 0 and 100.")
                Return
            End If

            Using writer As New StreamWriter(filePath, True)

                writer.WriteLine(regNo & "," & name & "," & marks)

            End Using

            Console.WriteLine("Student record saved successfully!")

        Catch ex As IOException
            Console.WriteLine("File error: " & ex.Message)

        Catch ex As UnauthorizedAccessException
            Console.WriteLine("You do not have permission to access the file.")

        Catch ex As Exception
            Console.WriteLine("An error occurred: " & ex.Message)

        End Try

    End Sub

    Sub DisplayStudentRecords()

        Try
            Console.WriteLine()
            Console.WriteLine("--- SAVED STUDENT RECORDS ---")

            If File.Exists(filePath) Then

                Dim records() As String = File.ReadAllLines(filePath)

                If records.Length = 0 Then
                    Console.WriteLine("No student records found.")
                Else

                    For Each record As String In records
                        Console.WriteLine(record)
                    Next

                End If

            Else
                Console.WriteLine("Student records file does not exist yet.")
            End If

        Catch ex As IOException
            Console.WriteLine("Unable to read the file: " & ex.Message)

        Catch ex As Exception
            Console.WriteLine("An error occurred: " & ex.Message)

        End Try

    End Sub

End Module