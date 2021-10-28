#
# newshell.sh
#
# シェルスクリプトの新規作成～編集
#

shopt -s expand_aliases
alias _ep="printf \"============================\n%s\n============================\n\" $@"

t0="./temp_text"
t1="./template.sh"

_ep "シェルスクリプトを作成します。"

# ファイル名の指定
read -p "ファイル名を入力してください : " fname

# ~/shell/ に移動
cd ~/shell

# 一時ファイルを作成
touch $t0

# 一時ファイルにヘッダ(ファイル名)を書き込む
echo "#" >> $t0
echo "# $fname" >> $t0

# テンプレートを結合
cat $t0 $t1 > $fname

# 実行権限付与
chmod u+x $fname

# 一時ファイルを削除
rm $t0

# エディタで開く
c9 $fname