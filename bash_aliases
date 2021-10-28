alias ls='ls --color=auto -F'
alias grep='grep --color=auto'
alias fgrep='fgrep --color=auto'
alias egrep='egrep --color=auto'
alias ll='ls -alF'
alias la='ls -A'
alias l='ls -CF'
alias less="less -R "

alias mysqldump="mysqldump --user=$C9_USER --host=$IP"
alias php="php -c ~/workspace/php.ini"
alias ..="cd .."

# - - - - - - - - - - - - - - - - - - - - -
# ファイルショートカット
# - - - - - - - - - - - - - - - - - - - - -
alias _udal="cp /mnt/m/06_Utility_n_TIPS/_arsenal/bash_aliases ~/.bash_aliases"
alias _rt="c9 open config/routes.rb"
alias _ge="c9 open Gemfile"

# - - - - - - - - - - - - - - - - - - - - -
# 省略コマンド(Linux)
# - - - - - - - - - - - - - - - - - - - - -
alias _rf="rm -rf"

# - - - - - - - - - - - - - - - - - - - - -
# シェル実行(引数無し)
# - - - - - - - - - - - - - - - - - - - - -
alias _ns="~/shell/newshell.sh"
alias _mp="~/shell/makeproject.sh"
alias _cp="~/shell/commit_and_push.sh"

# - - - - - - - - - - - - - - - - - - - - -
# シェル実行(引数有り)
# - - - - - - - - - - - - - - - - - - - - -
alias _nf="~/shell/newfile.sh"

# - - - - - - - - - - - - - - - - - - - - -
# Railsコマンド
# - - - - - - - - - - - - - - - - - - - - -

# (bundle)
alias _rbud="bundle update"
alias _rbia="bundle install"
alias _rbid="bundle install --without production"

# (db)
alias _rdmg="rails db:migrate"
alias _rdmr="rails db:migrate:reset"
alias _rdrb="rails db:rollback"
alias _rdsd="rails db:seed"

# (generate)
alias _rgct="rails generate controller"
alias _rgmi="rails generate migration"
alias _rgmo="rails generate model"
alias _rgti="rails generate integration_test"
alias _rgsc="rails generate scaffold"

# (destroy)
alias _rdsc="rails destroy controller"
alias _rdsm="rails destroy model"

# (test)
alias _rtst="rails test"
alias _rtco="rails test:controllers"
alias _rthl="rails test:helpers"
alias _rtin="rails test:integration"
alias _rtma="rails test:mailers"
alias _rtmo="rails test:models"

alias _rlco="rails console"
alias _rlcs="rails console --sandbox"
alias _rlrt="rails routes"
alias _rlsv="rails server -b $IP -p $PORT"

# - - - - - - - - - - - - - - - - - - - - -
# Gitコマンド
# - - - - - - - - - - - - - - - - - - - - -
alias _gtad="git add -A"
alias _gtbr="git branch"
alias _gtcob="git checkout -b"
alias _gtcof="git checkout -f"
alias _gtcom="git checkout master"
alias _gtcm="git commit -am"
alias _gtin="git init"
alias _gtpo="git push origin"
alias _gtph="git push heroku"
alias _gtst="git status"
alias _gtmg="git merge"

# - - - - - - - - - - - - - - - - - - - - -
# Herokuコマンド
# - - - - - - - - - - - - - - - - - - - - -
alias _hrcr="heroku create"
alias _hrdm="heroku run rails db:migrate"
alias _hrds="heroku run rails db:seed"
alias _hrco="heroku run console --sandbox"
alias _hrmn="heroku maintenance:on"
alias _hrmf="heroku maintenance:off"
alias _hrrn="heroku rename"
alias _hrpr="heroku pg:reset DATABASE"
alias _hrrs="heroku restart"
