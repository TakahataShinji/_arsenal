#
# newshell.sh
#
# �V�F���X�N���v�g�̐V�K�쐬�`�ҏW
#

shopt -s expand_aliases
alias _ep="printf \"============================\n%s\n============================\n\" $@"

t0="./temp_text"
t1="./template.sh"

_ep "�V�F���X�N���v�g���쐬���܂��B"

# �t�@�C�����̎w��
read -p "�t�@�C��������͂��Ă������� : " fname

# ~/shell/ �Ɉړ�
cd ~/shell

# �ꎞ�t�@�C�����쐬
touch $t0

# �ꎞ�t�@�C���Ƀw�b�_(�t�@�C����)����������
echo "#" >> $t0
echo "# $fname" >> $t0

# �e���v���[�g������
cat $t0 $t1 > $fname

# ���s�����t�^
chmod u+x $fname

# �ꎞ�t�@�C�����폜
rm $t0

# �G�f�B�^�ŊJ��
c9 $fname