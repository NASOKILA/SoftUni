
import { compute } from '../01-fundamentals/compute';

describe('Testing compute function ...', () => {
    
    it('Should return zero if number is negative', () => {
        const result = compute(-1);
        expect(result).toEqual(0);
    })

    it('Should increment positive number by 1', () => {
        const result = compute(1);
        expect(result).toBe(2);
    })
})


