@echo off
rem - - - - - - - - - - - - - - - - - - - - - - - -
rem 
rem �E�F�C�g�^�C�}�[
rem 
rem - - - - - - - - - - - - - - - - - - - - - - - -

echo �^�C�}�[���N�����܂��B
echo �҂�����[��]����͂��Ă��������B
echo - - - - - - - - - - - - - - - - - - - - - - - -

set /P MIN="���� : "

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem �҂����Ԃ�b�Ɋ��Z

set /a CNT=%MIN%*60

rem - - - - - - - - - - - - - - - - - - - - - - - -
rem �w�肳�ꂽ���ԑҋ@

timeout /t %CNT% /nobreak

rem �߂�l : 1
rem ���g�̂ݏI�� /b
exit /b 1

