import { VoteComponent } from './vote.component'; 

describe('Testing VoteComponent...', () => {

  it('Test upVote funcntion.', () => {
    const voteComponent = new VoteComponent();
    voteComponent.upVote();
    expect(voteComponent.totalVotes).toBe(1);
  });

  it('Test downVote funcntion.', () => {
    const voteComponent = new VoteComponent();
    voteComponent.downVote();
    expect(voteComponent.totalVotes).toBe(-1);
  });
  
});