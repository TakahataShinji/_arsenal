#
# commit_and_push.sh
#
# (Git)���݂̕ύX�����ׂăR�~�b�g�E�v�b�V������
#

shopt -s expand_aliases
alias _ep="printf \"============================\n%s\n============================\n\" $@"

_ep "���݂̕ύX�����ׂăR�~�b�g�E�v�b�V�����܂��B"

# �R�~�b�g���b�Z�[�W�̎w��
read -p "�R�~�b�g���b�Z�[�W����͂��Ă������� : " msg

# �S�t�@�C�����X�e�[�W���O
_ep "�f�B���N�g�����̃t�@�C�����X�e�[�W���O���Ă��܂�..."
git add -A

# �R�~�b�g
_ep "�R�~�b�g���Ă��܂�..."
git commit -am msg

# �v�b�V��(origin)
_ep "origin �Ƀv�b�V�����Ă��܂�..."
git push origin master

# �v�b�V��(heroku)
_ep "heroku �Ƀv�b�V�����Ă��܂�..."
git push heroku master

_ep "�������܂����B"
