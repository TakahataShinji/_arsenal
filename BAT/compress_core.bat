@echo off
rem 
rem �@�\�݌v�����k�o�b�`
rem 
rem ���� : �݌v���̃o�[�W����(**.**.**�`��)
rem 

rem �݌v���̃o�[�W����
set VRS=%1

rem �o�[�W������******�`���ɕϊ�('.'��''�ɒu��)
set VRR=%VRS:.=%

rem ���k�v���O����(Lhaplus)
set PRG="C:\Program Files (x86)\Lhaplus\Lhaplus.exe"

rem ���[�g�f�B���N�g��
set ROOT="C:\_Takaha-Q\20.Jobs\201608 �h�L�������g�C��\tags"

rem �e�o�[�W�����̃f�B���N�g��
set VDIR=%ROOT%\%VRS%

rem �݌v���t�@�C����
set DOC="�݌v��-MCP7(IB)Step2_�@�\�݌v��-(J).docx"

rem �݌v���t���p�X
set FDOC=%VDIR%\%DOC%

rem �ꎞ�t�@�C����
set TZP="�݌v��-MCP7(IB)Step2_�@�\�݌v��-(J).zip"

rem �ꎞ�t�@�C���t���p�X
set FTZP=%VDIR%\%TZP%

rem �ŏI�o��
set FOT="MCP7IB-2-STD;DOC(�@�\�݌v��);%VRR%.zip"

rem ���k���s
echo.
echo ���k���Ă��܂�...
%PRG% /c:zip /o:%VDIR% %FDOC%

rem �ꎞ�t�@�C�������l�[��
echo.
echo ���k�������܂����B
echo.
echo �t�@�C�����ړ����Ă��܂�...
rename %FTZP% %FOT%

rem �ŏI�o�͂����[�g�Ɉړ�
move %VDIR%\%FOT% %ROOT%\

