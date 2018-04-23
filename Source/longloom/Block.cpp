// Fill out your copyright notice in the Description page of Project Settings.

#include "Block.h"
#include "PaperSpriteComponent.h"
#include "ConstructorHelpers.h"
#include "PaperSprite.h"
#include "Engine/Blueprint.h"

ABlock::ABlock() {
	
	UPaperSpriteComponent* renderCmp = GetRenderComponent();
	renderCmp->SetSprite(ConstructorHelpers::FObjectFinder<UPaperSprite>
		(TEXT("/Game/2DSideScroller/Sprites/Block")).Object);
	
	SetActorScale3D(BLOCK_SCALE);
	// ABlock::setBlock();
}

void ABlock::setBlock(BlockType blockType, int32 resourceValue) {
	this->blockType = blockType;
	this->resourceValue = resourceValue;
	// set block sprite based on their type
	BlockTypeInfo blockInfo = StaticBlockInfo[(int)blockType];
	onBlockTypeChanged();
}

void ABlock::AOnDamaged() {

}

void ABlock::AOnDeath() {

}

void ABlock::damaged(int atkDamage) {
	hp -= atkDamage;
	if (hp < 0) ABlock::destruct();
	AOnDamaged();
}

void ABlock::destruct() {
	AOnDeath();
}

void ABlock::onHit() {
	UE_LOG(LogTemp, Warning, TEXT("BlockHit"));
}

