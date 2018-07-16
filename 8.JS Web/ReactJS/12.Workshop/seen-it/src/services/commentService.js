import requester from '../infrastructure/requester'
import observer from '../infrastructure/observer';

export default {
    create: {
        send: data  => requester.post('appdata', 'comments', 'kinvery', data),
        fail: res => observer.trigger(observer.events.notification, res.responseJSON.message)
    }
}