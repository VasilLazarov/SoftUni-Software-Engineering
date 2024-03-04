async function loadRepos() {
	const username = document.querySelector("#username").value;
	const info = await fetch(`https://api.github.com/users/${username}/repos`);
	console.log(info);
	const repos = await info.json();
	console.log(repos);

	const list = document.querySelector("#repos");
	//const removeOldLi = document.querySelector("li");
	//console.log(removeOldLi);
	//list.removeChild(removeOldLi);
	list.textContent = "";

	repos.forEach((repo) => {
		const newLiForAdding = document.createElement("li");
		const aTagForLi = document.createElement("a");
		aTagForLi.href = repo.html_url;
		aTagForLi.textContent = repo.full_name;
		newLiForAdding.appendChild(aTagForLi);
		list.appendChild(newLiForAdding);
	});
	
}