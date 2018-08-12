
import { getCurrencies } from '../02-arrays-and-strings/getCurrencies';

describe('Testing array of strings...', () => {
    
    it('Test length of the array.', () => {
        const result = getCurrencies();
        expect(result.length).toBe(3);
    })

    it('Test the full array.', () => {
        const result = getCurrencies();
        expect(result).toEqual(['USD', 'AUD', 'EUR'])
        //the order matters
    })

    it('Test if it contains the elements USD, AUD, EUR.', () => {
        const result = getCurrencies();
        expect(result).toContain('USD');
        expect(result).toContain('AUD');        
        expect(result).toContain('EUR');     
    })
})