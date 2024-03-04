async function loadCommits() {
    // Try it with Fetch API
    const username = document.querySelector("#username").value;
    const repo = document.querySelector("#repo").value;
    if(!username || !repo){
        // print out error message
        return;
    }
    const list = document.querySelector("#commits");
    list.innerHTML = "";

    /*const response = await fetch(`https://api.github.com/repos/${username}/${repo}/commits`);
    console.log(response);
    const commits = await response.json();*/
    /*mojem da napravim i await v await i napravo da vzemem array s .json 
    const commits = await (await fetch(`https://api.github.com/repos/${username}/${repo}/commits`)).json();*/
    /*mojem da go izvadim fetchvaneto v otdelna funkciq, no i neq trqbwa da i dadem await kogato q izwikwame */
    
    const commits = await getCommits(username, repo);
    console.log(commits);
    commits.forEach((currCommit) => {
        const item = document.createElement("li");
        item.textContent = `${currCommit.commit.author.name}: ${currCommit.commit.message}`;
        list.appendChild(item);
    });

    /*.then((res) => res.json())
    .then((commits) => {
        commits.forEach((currCommit) => {
            const item = document.createElement("li");
            item.textContent = `${currCommit.commit.author.name}: ${currCommit.commit.message}`;

            list.appendChild(item);

        });
    });*/
}
async function getCommits(username, repo){
    const response = await fetch(`https://api.github.com/repos/${username}/${repo}/commits`);
    console.log(response);
    const commits = await response.json();
    return commits;
}