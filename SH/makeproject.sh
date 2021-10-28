#
# makeproject.sh
#
# Rails�v���W�F�N�g��Git���[�J�����|�W�g����V�K�쐬����
#

shopt -s expand_aliases
alias _ep="printf \"============================\n%s\n============================\n\" $@"

_ep "�v���W�F�N�g���쐬���܂��B"

# �v���W�F�N�g���̎w��
read -p "�v���W�F�N�g������͂��Ă������� : " pjname

# Rails�o�[�W�����̎w��
read -p "Rails�o�[�W��������͂��Ă������� : " railsver

# workspace �f�B���N�g���Ɉړ�����
cd ~/workspace

# Rails���C���X�g�[������
_ep "Rails Ver.$railsver ���C���X�g�[�����Ă��܂�..."
gem install rails -v $railsver

# Rails�v���W�F�N�g���쐬����
_ep "Rails �v���W�F�N�g���쐬���Ă��܂�..."
rails _${railsver}_ new $pjname

# �v���W�F�N�g�̃g�b�v�f�B���N�g���Ɉړ�����
cd $pjname

# Git���[�J�����|�W�g�����쐬����
_ep "Git���|�W�g�����쐬���Ă��܂�..."
git init

# �S�t�@�C�����X�e�[�W���O
_ep "�f�B���N�g�����̃t�@�C�����X�e�[�W���O���Ă��܂�..."
git add -A

# ����̃R�~�b�g���s��
_ep "�R�~�b�g���Ă��܂�..."
git commit -am "�v���W�F�N�g�쐬"

_ep "�v���W�F�N�g���쐬���܂����B"
