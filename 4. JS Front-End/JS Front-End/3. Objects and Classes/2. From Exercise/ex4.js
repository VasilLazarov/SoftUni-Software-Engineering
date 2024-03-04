function solve(input){
    const movies = {};

    input.forEach((element) => {
        if(element.includes('addMovie')){
            const movieName = element.split("addMovie ")[1];
            movies[movieName] = {
                name: movieName
            };
        }else if(element.includes('directedBy')){
            const [movieName, director] = element.split(" directedBy ");
            if(movies.hasOwnProperty(movieName)){
                movies[movieName]['director'] = director;
            }
        }else if(element.includes('onDate')){
            const [movieName, date] = element.split(" onDate ");
            if(movies.hasOwnProperty(movieName)){
                movies[movieName]['date'] = date;
            }
        }
    });
    Object.values(movies).filter((obj) => {
        return Object.keys(obj).length === 3;
    }).forEach((movie) => {
        console.log(JSON.stringify(movie));
    });
}
solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]);