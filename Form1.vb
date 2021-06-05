Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Public Class FrmMain

    Public Const Vowels As String = "aeiou" 'Static variable consisting of Vowels.
    Public Const StrIgnore As String = "1234567890!@#$%^&*()-_=+[]{};:<>\|/?,." 'Static variable consisting of Numbers and Symbols.

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click 'Clears the Input and Output Textboxes.
        TxtEnglishInput.Clear()
        TxtPigLatinOutput.Clear()
    End Sub

    Private Sub BtnTranslate_Click(sender As Object, e As EventArgs) Handles BtnTranslate.Click

        Dim StrInput As String = TxtEnglishInput.Text 'Sets the text in the Input Textbox to a variable.
        Dim WordArray(0) As String 'Dynamically sized array to house the individual words taken from StrInput. The elements in this array are processed so as to be translated without error.
        Dim rgx As Regex = New Regex("([a-zA-Z]+)|([0-9]+)") 'Regex pattern for every word or numeric sequence.
        Dim StrSplit() As String = rgx.Split(StrInput) 'StrSplit is a string array that contains the input from StrInput split by the pattern of rgx. The elements in this array are raw.
        Dim Iteration As Integer = 0 'Iteration variable used to manually select words in a sequence.

        If StrInput = "" Then 'Should the user try and translate blank strings, sets the Textboxes to their default placeholder text.
            TxtEnglishInput.Text = "Type English here."
            TxtPigLatinOutput.Text = "Get Pig Latin here."
            Exit Sub
        End If

        For i As Integer = 0 To StrSplit.Length - 1 'This section of code is for taking in raw strings via StrSplit and loading WordArray with processed strings ripe for translation.
            Do While StrSplit(i) <> Nothing 'Ignores cases when elements of StrSplit array = nothing.

                If StrSplit(i).IndexOfAny(" ") <> -1 Then 'Checks if an element of StrSplit returns positive for containing a space. ("-1" = negative. ("<> -1" = not negative))
                    'This is used to remove the tailing whitespace character at the end of a word and to move it to the next element in WordArray
                    For x As Integer = 0 To StrSplit(i).Length - 1 'For x as 0 to the length of the current string -1
                        Array.Resize(WordArray, WordArray.Length + 2) 'Resize the WordArray so as to fit a whitespace character as one array, and a word or numeric sequence as the next element.
                        WordArray(Iteration + 1) = StrSplit(i).Substring(x, 1) 'Sets the last character of a string (whitespace) to a the next element in the array.
                        Iteration = Iteration + 2 'Iterates the iteration variable to be ahead of the latest element
                    Next
                    Exit Do
                End If

                If StrSplit(i) <> " " Then 'If the element of StrSplit does not equal space.
                    'WordArray(iteration) by default equals "", on first pass WordArray(Iteration) will come to equal "" + whatever is in StrSplit(i).
                    'Should the next element in StrSplit(i) be another word and not a whitespace character, WordArray(Iteration) will come to equal whatever was in StrSplit(i) on the first pass and whatever is it it on each and every subsequent pass.
                    WordArray(Iteration) = WordArray(Iteration) & StrSplit(i)
                    StrSplit(i) = "" 'Clears the element of StrSplit(i) after parsing it to avoid unintended repitition.
                End If
            Loop
        Next

        For f As Integer = 0 To WordArray.Length - 1 'This section is for Selecting, Translating, and adding the finishing touches to Strings.
            Dim LastChar As Char = "" 'Variable for the last character of a string
            Select Case f >= 0
                Case f >= 0

                    If WordArray(f) Is Nothing Then 'Ignores cases string equals nothing.
                        Exit Select
                    End If

                    If ContainsSymbols(WordArray(f).ToCharArray) = True Then 'Checks if string contains a symbol or number.
                        If WordArray(f).IndexOfAny(StrIgnore) <> WordArray(f).Length - 1 Then 'Checks if any character but the last is symbol or number, exiting select i positive.
                            Exit Select
                        End If

                        If WordArray(f).IndexOfAny(StrIgnore) = WordArray(f).Length - 1 Then 'Checks if the last character of a string is a symbol or number.
                            LastChar = WordArray(f).Substring(WordArray(f).Length - 1) 'Sets LastChar variable to the last character of a string.
                            WordArray(f) = WordArray(f).Remove(WordArray(f).Length - 1) 'Updates the string value to the string minus the last character.
                            Translate(WordArray, f) 'Calls the Translate subroutine.
                            WordArray(f) &= LastChar 'Adds the last character back to the string after translation.
                        End If
                    Else 'For cases where there are no symbols or numbers in a string
                        Translate(WordArray, f) 'Calls the Translate subroutine.
                    End If
            End Select

        Next

        TxtPigLatinOutput.Text = String.Join("", WordArray) 'Concatenates the strings in WordArray to the Output Textbox.
    End Sub

    Private Sub Translate(ByVal arr As String(), ByVal ele As Integer)
        If arr(ele).Length = 0 And arr(ele).IndexOfAny(StrIgnore) = -1 Then 'For cases where the user inputs one lone symbol. Exits subroutine.
            Exit Sub
        End If

        Select Case arr(ele).Substring(0, 1).ToLower() 'Parses the first character of a string as lowercase for selection.
            Case "a", "e", "i", "o", "u"
                arr(ele) = arr.ElementAt(ele) & "way" 'If the first character is a vowel, add "way" to the end.

            Case Else 'For cases where the first character is not a vowel.
                Dim index = arr(ele).IndexOfAny(Vowels.ToArray) 'This variable holds the position of the first character that is a vowel, or -1 for no vowels. Used to check for vowels in a string.

                If HasCapitals(arr(ele).Substring(0, 1)) = True Then 'Checks if the first character is upper case.
                    arr(ele) = arr(ele).Replace(arr(ele).Substring(0, 1), arr(ele).Substring(0, 1).ToLower) 'Replaces the first character (upper case) with a lower case version.
                    If (index > -1) Then 'Checks if the string contains a vowel.
                        arr(ele) = arr(ele).Substring(index) & arr(ele).Remove(index) 'Moves the consonants before the first vowel to the end of the string.
                        arr(ele) = arr(ele).Substring(0, 1).ToUpper() & arr(ele).Substring(1) 'Makes the first character uppercase.
                        arr(ele) &= "ay" 'Adds "ay" to the end of the string.

                    ElseIf arr(ele) <> " " Then 'Used for cases where a word contains no consonants.
                        arr(ele) &= "ay" 'Adds "ay" to the end of the string.
                    End If

                ElseIf HasCapitals(arr(ele).Substring(0, 1)) = False Then 'Checks if the first character is not upper case.
                    If (index > -1) Then 'Checks if the string contains a vowel.
                        arr(ele) = arr(ele).Substring(index) & arr(ele).Remove(index) 'Moves the consonants before the first vowel to the end of the string.
                        arr(ele) &= "ay" 'Adds "ay" to the end of the string.

                    ElseIf arr(ele) <> " " Then 'Used for cases where a word contains no consonants.
                        arr(ele) &= "ay" 'Adds "ay" to the end of the string.
                    End If
                End If

        End Select
    End Sub

    Function HasCapitals(ByVal text As String) As Boolean 'This function returns a boolean value based on the case of the character parsed to it.
        For Each c As Char In text
            If (Char.IsUpper(c)) Then 'Returns true if there capital letters in the string.
                Return True
            End If
        Next
        Return False
    End Function

    Function ContainsSymbols(s As String) As Boolean 'This function returns a boolean if the string parsed to it contains any symbols or numbers
        Return s.IndexOfAny(StrIgnore) <> -1 'Returns true if there are any symbols or numbers in the string.
    End Function

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        End 'Ends the program.
    End Sub

End Class
