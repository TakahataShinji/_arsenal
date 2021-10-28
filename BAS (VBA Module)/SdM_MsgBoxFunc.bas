Attribute VB_Name = "SdM_MsgBoxFunc"
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
'
' SdM_MsgBoxFunc
' メッセージボックス
'
' - = - = - = - = - = - = - = - = - = - = - = - = - = -

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' Public関数
' - = - = - = - = - = - = - = - = - = - = - = - = - = -

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' 問い合わせメッセージボックスを表示
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' 引数   | msg      - String  : 表示するメッセージ
'        | ttl      - String  : (Optional)表示するタイトル
'        |                      デフォルト - "確認"
'        | warnIcon - Boolean : (Optional)警告アイコンを表示するか
'        |                      デフォルト -  False
'        |                      True  - 警告アイコンを表示
'        |                      False - 問い合わせアイコンを表示(デフォルト)
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' 戻り値 | Boolean : 押されたボタン
'        |           True  - 「はい」
'        |           False - 「いいえ」
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Public Function ShowYesNo(msg As String, _
                          Optional ttl As String = "確認", _
                          Optional warnIcon As Boolean = False) As Boolean
    
    Dim mbret
    Dim icon
    
    ' アイコンの判別
    If (warnIcon) Then
        icon = vbExclamation
    Else
        icon = vbQuestion
    End If

    ' メッセージボックス表示
    mbret = MsgBox(Prompt:=msg, _
                   Buttons:=vbYesNo + icon, _
                   Title:=ttl)
    
    ShowYesNo = (mbret = vbYes)

End Function

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' 情報メッセージボックスを表示
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' 引数   | msg - String : 表示するメッセージ
'        | ttl - String : (Optional)表示するタイトル
'        |                デフォルト - "情報"
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Public Sub ShowInfo(msg As String, _
                    Optional ttl As String = "情報")
    
    Call MsgBox(Prompt:=msg, _
                Buttons:=vbOKOnly + vbInformation, _
                Title:=ttl)

End Sub

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' 警告メッセージボックスを表示
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' 引数   | msg - String : 表示するメッセージ
'        | ttl - String : (Optional)表示するタイトル
'        |                デフォルト - "警告"
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Public Sub ShowWarn(msg As String, _
                    Optional ttl As String = "警告")
    
    Call MsgBox(Prompt:=msg, _
                Buttons:=vbOKOnly + vbExclamation, _
                Title:=ttl)

End Sub

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' エラーメッセージボックスを表示
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' 引数   | msg - String : 表示するメッセージ
'        | ttl - String : (Optional)表示するタイトル
'        |                デフォルト - "エラー"
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Public Sub ShowError(msg As String, _
                     Optional ttl As String = "エラー")
    
    Call MsgBox(Prompt:=msg, _
                Buttons:=vbOKOnly + vbCritical, _
                Title:=ttl)

End Sub
