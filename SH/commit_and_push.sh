#
# commit_and_push.sh
#
# (Git)現在の変更をすべてコミット・プッシュする
#

shopt -s expand_aliases
alias _ep="printf \"============================\n%s\n============================\n\" $@"

_ep "現在の変更をすべてコミット・プッシュします。"

# コミットメッセージの指定
read -p "コミットメッセージを入力してください : " msg

# 全ファイルをステージング
_ep "ディレクトリ内のファイルをステージングしています..."
git add -A

# コミット
_ep "コミットしています..."
git commit -am msg

# プッシュ(origin)
_ep "origin にプッシュしています..."
git push origin master

# プッシュ(heroku)
_ep "heroku にプッシュしています..."
git push heroku master

_ep "完了しました。"
