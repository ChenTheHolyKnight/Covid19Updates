

export class PostDataService{
    apiURL= 'https://192.168.1.3:45455/api/email'

    async postApiData(data) {

        return await fetch(this.apiURL, {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Access-Control-Allow-Origin':'http://192.168.1.3',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data),
        })
    }
}
