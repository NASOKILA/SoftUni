import { greet } from '../02-arrays-and-strings/greet';

describe('Testing greet function...', () => {

    it('Should return "Welcome " before name.', () => {
        const result = greet("Atanas");
        expect(result).toEqual("Welcome Atanas");

        const result2 = greet("Asi");
        expect(result2).toEqual("Welcome Asi");
    })
})