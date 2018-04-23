// Fill out your copyright notice in the Description page of Project Settings.

#include "TestActor.h"
#include "PaperSprite.h"
#include "PaperSpriteComponent.h"
#include "PaperSpriteActor.h"
#include "ConstructorHelpers.h"
ATestActor::ATestActor() {
	UPaperSpriteComponent* sprite = GetRenderComponent();
	sprite->SetSprite(ConstructorHelpers::FObjectFinder<UPaperSprite>(TEXT("/Game/2DSideScroller/Sprites/Ledge")).Object);
}