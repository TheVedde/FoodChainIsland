using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityExpert : MonoBehaviour
{
   
   public List<MyAbilityDescription> abilities;
   public static AbilityExpert inst;
   private void Awake() {
      if (inst == null) {
         inst = this;
      }else {
         Destroy(gameObject);
      }
      abilities = new List<MyAbilityDescription>() {
         AbilityExpert.inst.PlantAbility, AbilityExpert.inst.AntAbility,AbilityExpert.inst.SpiderAbility, 
         AbilityExpert.inst.MouseAbility, AbilityExpert.inst.LizardAbility, AbilityExpert.inst.RatAbility, 
         AbilityExpert.inst.BatAbility, AbilityExpert.inst.SnakeAbility, AbilityExpert.inst.RacoonAbility, 
         AbilityExpert.inst.FoxAbility, AbilityExpert.inst.LynxAbility, AbilityExpert.inst.WolfAbility, 
         AbilityExpert.inst.TigerAbility, AbilityExpert.inst.GatorAbility, AbilityExpert.inst.LionAbility, 
         AbilityExpert.inst.PolarBearAbility
      };
   }

   public void PlantAbility()
   {
      StateManager.ChangeState(new NeutralState()); 
      GUIManager.inst.HelpPanelText.text = "Does nothing. I dont know how you activated this ability.";

   }

   public void AntAbility()
   {
      StateManager.ChangeState(new SelectToMoveState(3, false));
      GUIManager.inst.DisplayAbilityText("Ant Ability");
      GUIManager.inst.HelpPanelText.text = "Pick a card and move it to an empty field of 1-3 spaces";
   }
   public void SpiderAbility() {
      //TODO: Move Two Animals 1 space each, It can currently still move the same animal twice 1 space.
      StateManager.ChangeState(new SpiderMoveState(1, true));
      StateManager.ChangeState(new SpiderMoveState(1, true));
   }

   public void LizardAbility()
   {
      StateManager.ChangeState(new RemovedUnstackedState());
      GUIManager.inst.DisplayAbilityText("Lizard Ability");
      GUIManager.inst.HelpPanelText.text = "Pick a card that is unstacked and remove it from the game";
   }

   public void MouseAbility()
   {
      StateManager.ChangeState(new SelectToMoveState(2, false)); 
      
      GUIManager.inst.DisplayAbilityText("Mouse Ability");
      
      GUIManager.inst.HelpPanelText.text = "Pick a card and move it to an empty field of 1-2 spaces";
   }

   public void RatAbility()
   {
      StateManager.ChangeState(new SelectToMoveState(2, true)); 
      
      GUIManager.inst.DisplayAbilityText("Rat Ability");
      GUIManager.inst.HelpPanelText.text = "Pick a card and move it to an empty field of EXACTLY 2 spaces";

   }

   public void BatAbility()
   {
      StateManager.ChangeState(new MoveState(99,  CardFactory.inst.CardList.Find(o => o.GetComponent<Card>().name == "Bat").GetComponent<Card>(), false)); 
      
      GUIManager.inst.DisplayAbilityText("Bat Ability");
      GUIManager.inst.HelpPanelText.text = "After eating with the bat, move it to ANY empty field";

   }

   public void SnakeAbility()
   {
      StateManager.ChangeState(new SnakeSelectToMoveState(0, false)); 
      GUIManager.inst.HelpPanelText.text = "Pick a card and swap location with another card of your choosing";

   }
   public void RacoonAbility() 
   { 
      StateManager.ChangeState(new SpecialNeutralState(new RacoonEatCardState(null)));
      
      GUIManager.inst.DisplayAbilityText("Racoon Ability");
      GUIManager.inst.HelpPanelText.text = "After eating with the Racoon, IF you eat an animal EXACTLY one lower than your selected card. You may discard an unstacked animal";

      //todo Racoon Ability: on your next turn. If you eat an animal exactly 1 below, then you discard 1 unstacked animal of your choice.
   }

   public void FoxAbility()
   {
      StateManager.ChangeState(new SpecialNeutralState(new FoxEatCardState(null))); 
      
      GUIManager.inst.DisplayAbilityText("Fox Ability");
      GUIManager.inst.HelpPanelText.text = "After eating with the fox, instead of moving in a cardinal direction. Move in a diagonal direction";

   }

   public void LynxAbility()
   {
      StateManager.ChangeState(new SpecialNeutralState(new LynxEatCardState(null)));
      
      GUIManager.inst.DisplayAbilityText("Lynx Ability");
      GUIManager.inst.HelpPanelText.text = "After eating with the Lynx, the animal must jump over 1 card in one of the Cardinal directions to eat";
      //TODO Lynx Ability: On your next turn, the animal must jump over 1 card in one of the Cardinal directions to eat.
   }

   public void WolfAbility()
   {
      StateManager.ChangeState( new MoveState(1, CardFactory.inst.CardList.Find(o => o.GetComponent<Card>().name == "Wolf").GetComponent<Card>(), true)); 
      
      GUIManager.inst.DisplayAbilityText("Wolf Ability");
      GUIManager.inst.HelpPanelText.text = "AFTER eating with the wolf, move it to an empty field of EXACTLY 1 space";

   }

   public void TigerAbility()
   {
      StateManager.ChangeState(new SpecialNeutralState(new TigerEatCardState(null))); 
      
      GUIManager.inst.DisplayAbilityText("Tiger Ability");
      GUIManager.inst.HelpPanelText.text = "After eating with the Tiger, you HAVE to move 2 spaces to eat";

   }

   public void GatorAbility()
   {
      StateManager.ChangeState(new SpecialNeutralState(new GatorEatCardState(null))); 
      
      GUIManager.inst.DisplayAbilityText("Gator Ability");
      GUIManager.inst.HelpPanelText.text = "After eating with the Gator, the prey moves into the preditors space and goes to the bottom, instead of the other way around";

   }

   public void LionAbility()
   {
      StateManager.ChangeState(new SpecialNeutralState(new LionEatCardState(null))); 
      
      GUIManager.inst.DisplayAbilityText("Lion Ability");
      GUIManager.inst.HelpPanelText.text = "After eating with the lion, the next selected card can only eat exactly 1 below instead of 1-3 below";

   }
   public void PolarBearAbility() { StateManager.ChangeState(new PolarBearNeutralState()); 
      GUIManager.inst.DisplayAbilityText("Polar Bear Ability");
      GUIManager.inst.HelpPanelText.text = "After eating with the Polar Bear, it cannot be used on the next turn";

      
   }

   public void WhaleAbility()
   {
      StateManager.ChangeState(new SelectToMoveState(99, false)); 
      
      GUIManager.inst.RemoveAbilityText();
      GUIManager.inst.DisplayAbilityText("Whale Ability");
      GUIManager.inst.HelpPanelText.text = "Move a card to any empty space";

   }

   public void SharkAbility()
   {
      StateManager.ChangeState(new SpecialNeutralState(new SharkEatCardState(null))); 
      GUIManager.inst.RemoveAbilityText();
      GUIManager.inst.DisplayAbilityText("Shark Ability");
      GUIManager.inst.HelpPanelText.text = "Choose a card, it can now eat any card lower than itself";

   }
}
