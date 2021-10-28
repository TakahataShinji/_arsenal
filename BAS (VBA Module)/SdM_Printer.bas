Attribute VB_Name = "SdM_Printer"
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
'
' SdM_Printer
' ���
'
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' �ˑ� | SdM_MsgBoxFunc
' - = - = - = - = - = - = - = - = - = - = - = - = - = -

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' Public�֐�
' - = - = - = - = - = - = - = - = - = - = - = - = - = -

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' �w�肳�ꂽ���[�N�V�[�g�����
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' ����   | sht     - Worksheet : (ByRef)������郏�[�N�V�[�g
'        | top     - Integer   : ����͈͏�[�̍s�ԍ�
'        | btm     - Integer   : ����͈͉��[�̍s�ԍ�
'        | lft     - Integer   : ����͈͍��[�̗�ԍ�
'        | rgt     - Integer   : ����͈͉E�[�̗�ԍ�
'        | centerH - Boolean   : (Optional)���E�����ɔz�u���邩
'        |                       �f�t�H���g -  False
'        |                       True  - �p���̍��E�����ɔz�u����
'        |                       False - �p���̍��E�����ɔz�u���Ȃ�(���l��)
'        | centerV - Boolean   : (Optional)�㉺�����ɔz�u���邩
'        |                       �f�t�H���g -  False
'        |                       True  - �p���̏㉺�����ɔz�u����
'        |                       False - �p���̏㉺�����ɔz�u���Ȃ�(��l��)
'        | showPv  - Boolean   : (Optional)����O�Ƀv���r���[��\�����邩
'        |                       �f�t�H���g -  False
'        |                       True  - �v���r���[��\������
'        |                       False - �v���r���[��\�����Ȃ�
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' �� 1 x �c 1 �y�[�W�Ɉ��
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Public Sub PrintWorksheet(ByRef sht As Worksheet, _
                          top As Integer, _
                          lft As Integer, _
                          btm As Integer, _
                          rgt As Integer, _
                          Optional centerH As Boolean = False, _
                          Optional centerV As Boolean = False, _
                          Optional showPv As Boolean = False)

    ' �w�肳�ꂽ�V�[�g�����݂��Ȃ��ꍇ�͔�����
    If sht Is Nothing Then
        SdM_MsgBoxFunc.ShowError ("�w�肳�ꂽ�V�[�g�����݂��܂���B")
        Exit Sub
    End If
    
    With sht
        
        ' ����͈͎w��(A1�`��)
        .PageSetup.PrintArea = .Range(.Cells(top, lft), .Cells(btm, rgt)).Address
        
        ' �㉺�E���E����
        .PageSetup.CenterHorizontally = centerH
        .PageSetup.CenterVertically = centerV
        
        ' 1 x 1 �y�[�W�Ɉ��
        .PageSetup.Zoom = False
        .PageSetup.FitToPagesWide = 1
        .PageSetup.FitToPagesTall = 1
        
        ' ���(�v���r���[�̗L�����w��)
        .PrintOut preview:=showPv
        
    End With        ' sht

End Sub

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' �w�肳�ꂽ�t�@�C���̎w�肳�ꂽ�V�[�g�����
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' ����   | fname   - String    : �������t�@�C����
'        | shtnum  - Integer   : �������V�[�g�ԍ�
'        | top     - Integer   : ����͈͏�[�̍s�ԍ�
'        | btm     - Integer   : ����͈͉��[�̍s�ԍ�
'        | lft     - Integer   : ����͈͍��[�̗�ԍ�
'        | rgt     - Integer   : ����͈͉E�[�̗�ԍ�
'        | centerH - Boolean   : (Optional)���E�����ɔz�u���邩
'        |                       �f�t�H���g -  False
'        |                       True  - �p���̍��E�����ɔz�u����
'        |                       False - �p���̍��E�����ɔz�u���Ȃ�(���l��)
'        | centerV - Boolean   : (Optional)�㉺�����ɔz�u���邩
'        |                       �f�t�H���g -  False
'        |                       True  - �p���̏㉺�����ɔz�u����
'        |                       False - �p���̏㉺�����ɔz�u���Ȃ�(��l��)
'        | showPv  - Boolean   : (Optional)����O�Ƀv���r���[��\�����邩
'        |                       �f�t�H���g -  False
'        |                       True  - �v���r���[��\������
'        |                       False - �v���r���[��\�����Ȃ�
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' �� 1 x �c 1 �y�[�W�Ɉ��
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

    Dim wb As Workbook      ' ���[�N�u�b�N
    Dim ws As Worksheet     ' ���[�N�V�[�g

    ' �t�@�C�����J��
    ' �w�肳�ꂽ�t�@�C�����J���Ȃ��ꍇ�͔�����
    Set wb = Workbooks.Open(fname)
    If wb Is Nothing Then
        SdM_MsgBoxFunc.ShowError ("�w�肳�ꂽ�t�@�C�����J���܂���B")
        Exit Sub
    End If
    
    ' ���[�N�V�[�g���擾
    ' �w�肳�ꂽ�V�[�g�����݂��Ȃ��ꍇ�͔�����
    Set ws = wb.Sheets(shtnum)
    If ws Is Nothing Then
        SdM_MsgBoxFunc.ShowError ("�w�肳�ꂽ�V�[�g�����݂��܂���B")
        Exit Sub
    End If
    
    ' ���
    Call PrintWorksheet(ws, top, lft, btm, rgt, centerH, centerV, showPv)

End Sub
