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

    const songsForPrint = songs.map((line) => {
        const [typeList, name, time] = line.split('_');
        const song = new Song(typeList, name, time);
        return song;
    })
    .filter((song) => {
        if(wantedTypeList === 'all'){
            return song;
        }
        return song.typeList === wantedTypeList;
    })
    .map((song) => song.name);
    
    console.log(songsForPrint.join("\n"));
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