Attribute VB_Name = "SdM_MsgBoxFunc"
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
'
' SdM_MsgBoxFunc
' ���b�Z�[�W�{�b�N�X
'
' - = - = - = - = - = - = - = - = - = - = - = - = - = -

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' Public�֐�
' - = - = - = - = - = - = - = - = - = - = - = - = - = -

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' �₢���킹���b�Z�[�W�{�b�N�X��\��
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' ����   | msg      - String  : �\�����郁�b�Z�[�W
'        | ttl      - String  : (Optional)�\������^�C�g��
'        |                      �f�t�H���g - "�m�F"
'        | warnIcon - Boolean : (Optional)�x���A�C�R����\�����邩
'        |                      �f�t�H���g -  False
'        |                      True  - �x���A�C�R����\��
'        |                      False - �₢���킹�A�C�R����\��(�f�t�H���g)
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' �߂�l | Boolean : �����ꂽ�{�^��
'        |           True  - �u�͂��v
'        |           False - �u�������v
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Public Function ShowYesNo(msg As String, _
                          Optional ttl As String = "�m�F", _
                          Optional warnIcon As Boolean = False) As Boolean
    
    Dim mbret
    Dim icon
    
    ' �A�C�R���̔���
    If (warnIcon) Then
        icon = vbExclamation
    Else
        icon = vbQuestion
    End If

    ' ���b�Z�[�W�{�b�N�X�\��
    mbret = MsgBox(Prompt:=msg, _
                   Buttons:=vbYesNo + icon, _
                   Title:=ttl)
    
    ShowYesNo = (mbret = vbYes)

End Function

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' ��񃁃b�Z�[�W�{�b�N�X��\��
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' ����   | msg - String : �\�����郁�b�Z�[�W
'        | ttl - String : (Optional)�\������^�C�g��
'        |                �f�t�H���g - "���"
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Public Sub ShowInfo(msg As String, _
                    Optional ttl As String = "���")
    
    Call MsgBox(Prompt:=msg, _
                Buttons:=vbOKOnly + vbInformation, _
                Title:=ttl)

End Sub

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' �x�����b�Z�[�W�{�b�N�X��\��
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' ����   | msg - String : �\�����郁�b�Z�[�W
'        | ttl - String : (Optional)�\������^�C�g��
'        |                �f�t�H���g - "�x��"
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Public Sub ShowWarn(msg As String, _
                    Optional ttl As String = "�x��")
    
    Call MsgBox(Prompt:=msg, _
                Buttons:=vbOKOnly + vbExclamation, _
                Title:=ttl)

End Sub

' - = - = - = - = - = - = - = - = - = - = - = - = - = -
' �G���[���b�Z�[�W�{�b�N�X��\��
' - - - - - - - - - - - - - - - - - - - - - - - - - - -
' ����   | msg - String : �\�����郁�b�Z�[�W
'        | ttl - String : (Optional)�\������^�C�g��
'        |                �f�t�H���g - "�G���["
' - = - = - = - = - = - = - = - = - = - = - = - = - = -
Public Sub ShowError(msg As String, _
                     Optional ttl As String = "�G���[")
    
    Call MsgBox(Prompt:=msg, _
                Buttons:=vbOKOnly + vbCritical, _
                Title:=ttl)

End Sub
