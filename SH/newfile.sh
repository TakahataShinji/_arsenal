#
# newfile.sh 
#
# �e�L�X�g�t�@�C���̐V�K�쐬�`�ҏW
#
# �g����
# newfile.sh �쐬�������t�@�C����
# _nf �쐬�������t�@�C����
#

shopt -s expand_aliases
alias _ep="printf \"============================\n%s\n============================\n\" $@"

# �t�@�C�����쐬
touch $@

# �G�f�B�^�ŊJ��
c9 $@
