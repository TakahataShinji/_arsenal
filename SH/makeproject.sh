#
# makeproject.sh
#
# RailsプロジェクトとGitローカルリポジトリを新規作成する
#

shopt -s expand_aliases
alias _ep="printf \"============================\n%s\n============================\n\" $@"

_ep "プロジェクトを作成します。"

# プロジェクト名の指定
read -p "プロジェクト名を入力してください : " pjname

# Railsバージョンの指定
read -p "Railsバージョンを入力してください : " railsver

# workspace ディレクトリに移動する
cd ~/workspace

# Railsをインストールする
_ep "Rails Ver.$railsver をインストールしています..."
gem install rails -v $railsver

# Railsプロジェクトを作成する
_ep "Rails プロジェクトを作成しています..."
rails _${railsver}_ new $pjname

# プロジェクトのトップディレクトリに移動する
cd $pjname

# Gitローカルリポジトリを作成する
_ep "Gitリポジトリを作成しています..."
git init

# 全ファイルをステージング
_ep "ディレクトリ内のファイルをステージングしています..."
git add -A

# 初回のコミットを行う
_ep "コミットしています..."
git commit -am "プロジェクト作成"

_ep "プロジェクトを作成しました。"
