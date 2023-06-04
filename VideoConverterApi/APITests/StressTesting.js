import http from 'k6/http'
import {sleep} from 'k6'
import {check} from 'k6'

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        {duration: '20s', target: 30},
        {duration: '30s', target: 30},
        {duration: '20s', target: 70},
        {duration: '30s', target: 70},
        {duration: '20s', target: 110},
        {duration: '30s', target: 110},
        {duration: '20s', target: 150},
        {duration: '30s', target: 150},
        {duration: '90s', target: 0}
    ]
};

export default () =>{

    const url = 'https://localhost:44337/removeaudio';

    const payload = JSON.stringify({
        inputFileName: 'test.mp4',
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const res = http.post(url, payload, params);
    check(res, {
        'is status 200': (r) => r.status === 200,
    });

    sleep(1);
}