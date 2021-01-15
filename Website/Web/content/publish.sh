wget --recursive --no-host-directories --page-requisites --span-hosts --restrict-file-names=windows --no-parent --directory-prefix=_public --domains=localhost http://localhost:8000

git add -A
git commit -m "Static publish"
git push