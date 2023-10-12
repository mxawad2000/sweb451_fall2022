REM  Initialize Git (Version Control):  
git init
git add .
git commit -m "initial commit"

REM Create a .gitignore File for Unity: create/edit 
REM edit/notepad/ .gitignore (see note section).

REM Point Git To Your Existing Repo URL
set URL="https://github.com/mxawad2000/sweb451_fall2022.git"
git remote add origin %URL%

git commit -m "initial commit"

REM Verify That Your Repo Is Connected
git remote -v
REM Push Changes To GitHub Repo
git push -u origin spaceship
git commit -m "initial commit"

