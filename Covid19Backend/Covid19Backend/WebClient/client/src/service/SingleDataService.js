export const ApiCallType = {DailyReport:'webdata'}

export class SingleDataService{
    apiURL= 'https://192.168.1.3:45457/api/'

    async getApiData(type) {
        let builtUrl = '';
        switch(type) {
            case ApiCallType.DailyReport:
                builtUrl += this.apiURL+type;
                break;
        }

        const response = await fetch(builtUrl);
        return await response.json();
    }
}
