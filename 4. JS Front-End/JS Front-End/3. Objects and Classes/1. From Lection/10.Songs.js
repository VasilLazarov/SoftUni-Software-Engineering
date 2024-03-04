/*class Song{
    constructor(typeList, name, time){
        this.typeList = typeList;
        this.name = name;
        this.time = time;
    }
}*/
function createSong(inputArr){
    class Song{
        constructor(typeList, name, time){
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }
    //const n = inputArr.shift();
    const [_, ...songs] = inputArr;
    
    const wantedTypeList = songs.pop();
    const songsArr = [];
    songs.forEach(line => {
        const [typeList, name, time] = line.split('_');
        const song = new Song(typeList, name, time);
        songsArr.push(song);
    });
    const songsFromThisTypelist = songsArr.filter((songEl) => {
        return songEl.typeList === wantedTypeList;
    });

    /*const checkWantedTypeListIsValid = songsArr.find((songEl) => {
        return songEl.typeList === wantedTypeList;
    });
    if(checkWantedTypeListIsValid){
        songsFromThisTypelist.forEach((songEl) => {
            console.log(songEl.name);
        });
    }
    else{
        songsArr.forEach((songEl) => {
            console.log(songEl.name);
        });
    }*/

    /*other way */
    if(songsFromThisTypelist.length !== 0){
        songsFromThisTypelist.forEach((songEl) => {
            console.log(songEl.name);
        });
    }
    else{
        songsArr.forEach((songEl) => {
            console.log(songEl.name);
        });
    }
    
}

createSong([3, 
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite'
]);
createSong([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']
);
createSong([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']
);