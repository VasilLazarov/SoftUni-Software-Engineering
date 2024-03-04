function loadCommits() {
    // Try it with Fetch API
    const username = document.querySelector("#username").value;
    const repo = document.querySelector("#repo").value;
    if(!username || !repo){
        // print out error message
        return;
    }
    const list = document.querySelector("#commits");
    list.innerHTML = "";
    fetch(`https://api.github.com/repos/${username}/${repo}/commits`)
    .then((res) => res.json())
    .then((commits) => {
        commits.forEach((currCommit) => {
            const item = document.createElement("li");
            item.textContent = `${currCommit.commit.author.name}: ${currCommit.commit.message}`;

            list.appendChild(item);

        });
    });
}