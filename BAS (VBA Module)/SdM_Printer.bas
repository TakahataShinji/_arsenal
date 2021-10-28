Attribute VB_Name = "SdM_Printer"
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
'
' SdM_Printer
' 印刷
'
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' 依存 | SdM_MsgBoxFunc
' - = - = - = - = - = - = - = - = - = - = - = - = - = -

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' Public関数
' - = - = - = - = - = - = - = - = - = - = - = - = - = -

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' 指定されたワークシートを印刷
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' 引数   | sht     - Worksheet : (ByRef)印刷するワークシート
'        | top     - Integer   : 印刷範囲上端の行番号
'        | btm     - Integer   : 印刷範囲下端の行番号
'        | lft     - Integer   : 印刷範囲左端の列番号
'        | rgt     - Integer   : 印刷範囲右端の列番号
'        | centerH - Boolean   : (Optional)左右中央に配置するか
'        |                       デフォルト -  False
'        |                       True  - 用紙の左右中央に配置する
'        |                       False - 用紙の左右中央に配置しない(左詰め)
'        | centerV - Boolean   : (Optional)上下中央に配置するか
'        |                       デフォルト -  False
'        |                       True  - 用紙の上下中央に配置する
'        |                       False - 用紙の上下中央に配置しない(上詰め)
'        | showPv  - Boolean   : (Optional)印刷前にプレビューを表示するか
'        |                       デフォルト -  False
'        |                       True  - プレビューを表示する
'        |                       False - プレビューを表示しない
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' 横 1 x 縦 1 ページに印刷
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Public Sub PrintWorksheet(ByRef sht As Worksheet, _
                          top As Integer, _
                          lft As Integer, _
                          btm As Integer, _
                          rgt As Integer, _
                          Optional centerH As Boolean = False, _
                          Optional centerV As Boolean = False, _
                          Optional showPv As Boolean = False)

    ' 指定されたシートが存在しない場合は抜ける
    If sht Is Nothing Then
        SdM_MsgBoxFunc.ShowError ("指定されたシートが存在しません。")
        Exit Sub
    End If
    
    With sht
        
        ' 印刷範囲指定(A1形式)
        .PageSetup.PrintArea = .Range(.Cells(top, lft), .Cells(btm, rgt)).Address
        
        ' 上下・左右中央
        .PageSetup.CenterHorizontally = centerH
        .PageSetup.CenterVertically = centerV
        
        ' 1 x 1 ページに印刷
        .PageSetup.Zoom = False
        .PageSetup.FitToPagesWide = 1
        .PageSetup.FitToPagesTall = 1
        
        ' 印刷(プレビューの有無を指定)
        .PrintOut preview:=showPv
        
    End With        ' sht

End Sub

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' 指定されたファイルの指定されたシートを印刷
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' 引数   | fname   - String    : 印刷するファイル名
'        | shtnum  - Integer   : 印刷するシート番号
'        | top     - Integer   : 印刷範囲上端の行番号
'        | btm     - Integer   : 印刷範囲下端の行番号
'        | lft     - Integer   : 印刷範囲左端の列番号
'        | rgt     - Integer   : 印刷範囲右端の列番号
'        | centerH - Boolean   : (Optional)左右中央に配置するか
'        |                       デフォルト -  False
'        |                       True  - 用紙の左右中央に配置する
'        |                       False - 用紙の左右中央に配置しない(左詰め)
'        | centerV - Boolean   : (Optional)上下中央に配置するか
'        |                       デフォルト -  False
'        |                       True  - 用紙の上下中央に配置する
'        |                       False - 用紙の上下中央に配置しない(上詰め)
'        | showPv  - Boolean   : (Optional)印刷前にプレビューを表示するか
'        |                       デフォルト -  False
'        |                       True  - プレビューを表示する
'        |                       False - プレビューを表示しない
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' 横 1 x 縦 1 ページに印刷
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Private Sub PrintWorksheet_F(fname As String, _
                             shtnum As Integer, _
                             top As Integer, _
                             lft As Integer, _
                             btm As Integer, _
                             rgt As Integer, _
                             Optional centerH As Boolean = False, _
                             Optional centerV As Boolean = False, _
                             Optional showPv As Boolean = False)

    Dim wb As Workbook      ' ワークブック
    Dim ws As Worksheet     ' ワークシート

    ' ファイルを開く
    ' 指定されたファイルが開けない場合は抜ける
    Set wb = Workbooks.Open(fname)
    If wb Is Nothing Then
        SdM_MsgBoxFunc.ShowError ("指定されたファイルが開けません。")
        Exit Sub
    End If
    
    ' ワークシートを取得
    ' 指定されたシートが存在しない場合は抜ける
    Set ws = wb.Sheets(shtnum)
    If ws Is Nothing Then
        SdM_MsgBoxFunc.ShowError ("指定されたシートが存在しません。")
        Exit Sub
    End If
    
    ' 印刷
    Call PrintWorksheet(ws, top, lft, btm, rgt, centerH, centerV, showPv)

End Sub
