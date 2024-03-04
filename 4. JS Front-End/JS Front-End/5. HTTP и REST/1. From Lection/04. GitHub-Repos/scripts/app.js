function loadRepos() {
   //const repos = fetch("https://api.github.com/users/testnakov/repos");
   //console.log(repos);


   /*fetch("https://api.github.com/users/testnakov/repos")
   .then((res) => {
      const body =  res.json();
      console.log(body);
   })
   .catch((err) => console.log(err));*/

   /*fetch("https://api.github.com/users/testnakov/repos")
   .then((res) => res.json())
   .then((body) => console.log(body));*/

   
   fetch("https://api.github.com/users/testnakov/repos")
   .then((res) => res.json())
   .then((body) => {
      body.forEach((repo) => {
         const repoName = document.createElement("h2");
         repoName.textContent = repo.name;
         document.querySelector("body").appendChild(repoName);
      });
   });


}