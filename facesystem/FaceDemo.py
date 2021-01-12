# -*- coding: utf-8 -*-
"""
Created on Mon Dec  7 14:48:01 2020

@author: Windink
"""
import cv2
import numpy as np
from sklearn.metrics import classification_report
from keras.engine import Model

from keras.models import load_model
from keras.layers import Flatten, Dense, Input,Dropout
from keras.applications import VGG16
from keras_vggface.vggface import VGGFace
from imagUnit import load_data,IMAGE_CLASSES,resize_image,cvtLabels,load_orldata
from Smote import Smote_main
from keras.losses import categorical_crossentropy
from keras.optimizers import SGD,Adam
from keras.utils import np_utils
from keras.callbacks import ModelCheckpoint,EarlyStopping
from Face_OwnCoding import Own_main
import matplotlib.pyplot as plt
from keras.preprocessing.image import ImageDataGenerator
from sklearn.metrics import classification_report

NB_CLASS = 0
HIDDEN_DIM = 2048
BATCH_SIZE = 32
NB_EPOCHS = 100  
    
def bulid_model():
    vgg_model = VGGFace(include_top=False, input_shape=(64, 64, 3))
    last_layer = vgg_model.get_layer('pool5').output
    x = Flatten(name='flatten')(last_layer)
    x = Dense(HIDDEN_DIM, activation='relu', name='fc6')(x)
    #x = Dense(HIDDEN_DIM, activation='relu', name='fc7')(x)
    x= Dropout(0.4)(x)
    out = Dense(NB_CLASS, activation='softmax', name='fc8')(x)
    custom_vgg_model = Model(vgg_model.input, out)
    custom_vgg_model.summary()
    return custom_vgg_model

def train(model,images,lables):
    sgd = SGD(lr=0.001, decay=1e-6, momentum=0.9, nesterov=True)
    
    adam = Adam(lr = 0.001)
    
    model.compile(loss=categorical_crossentropy,optimizer=sgd,metrics=["accuracy"])
    
    modelcheckpoint = ModelCheckpoint(filepath="./data/model/tensorflow-acc_{accuracy:.2f}.h5",
                                      save_best_only=True,verbose=1,period=30,monitor="accuracy")
    
    earlyStopping = EarlyStopping(monitor='accuracy', patience=15)
    
   
    
    # datagen = ImageDataGenerator(
    #         width_shift_range=0.1,
    #         height_shift_range=0.1,
    #         shear_range=0.1,
    #         zoom_range=0.1,
    #     )
    history = model.fit(images,lables,batch_size =BATCH_SIZE,
                        epochs = NB_EPOCHS,callbacks=[modelcheckpoint,earlyStopping])
    
    
    # history = model.fit_generator(datagen.flow(images,lables,batch_size=BATCH_SIZE),
    #                     samples_per_epoch = images.shape[0],
    #                     epochs = NB_EPOCHS,callbacks=[modelcheckpoint,earlyStopping],
    #                     ) 
    
    draw_acc(history)
    
    return model
    
    
def draw_acc(history):
    acc = history.history['accuracy']
    plt.plot(acc)
    plt.title('Training and Validation Accuracy')
    plt.xlabel('Epochs')
    plt.ylabel('Accuracy')
    plt.legend()
    plt.show()

MODEL_PATH = "./data/model/tensorflow-acc_1.00.h5"    
def load_models():
    model = load_model(MODEL_PATH)
    return model

def evaluate(model,images,labels): 
    #images,lables = load_data("./data/me")
    score = model.evaluate(images,labels,batch_size = 64)
    print("loss:%.3f acc:%.3f"%(score[0],score[1]))
       
    score = model.predict(images)
    y_pred = np.argmax(score,axis = 1)
    y_true = np.argmax(labels,axis = 1)
    print(classification_report(y_true, y_pred))
    
  
    
def predicts(model):
    images,_ = load_data("data/me",ispredict=True)
    score = model.predict(images)
    y_pred = np.argmax(score,axis = 1)
    y_true = np.zeros(len(images))
    print(classification_report(y_true, y_pred))
    
    
    # model = load_models()
    # img = cv2.imread("data/me/me77.jpg")
    # img = resize_image(img)
    # imgs = np.expand_dims(img, axis=0)
    # imgs = imgs.astype('float32') / 255
    # #print(img)
    # score = model.predict(imgs)
    # np.set_printoptions(formatter={'float': '{: 0.5f}'.format})
    # print(score)
    # print(np.max(score))
    # class_num =np.argmax(score,axis = 1)
    # print(class_num)
    #print(IMAGE_CLASSES[class_num])
  
    
def Check(images,lables):
    print(NB_CLASS)
    lab = []
    lab.append("me")
    lable = cvtLabels(lab)
    lable = np_utils.to_categorical(lable,NB_CLASS)
    
    img = cv2.imread("data/me/me11.jpg")
    img = resize_image(img)
    imgs = np.expand_dims(img, axis=0)
    print(imgs.shape)
    imgs = imgs.astype('float32') / 255
    print(imgs.shape)
    
    
    models = load_models()
    models.summary()
   # model = Model(inputs=models.input, outputs=models.get_layer("fc7").output)
    out = models.get_layer("fc7").output
    x = Dense(NB_CLASS, activation='softmax', name='fc8')(out)
    model =Model(models.input,x)
    model.summary()
    print(images.shape)
    print(lables.shape)
    images = np.append(images,imgs,axis = 0)
    lables = np.append(lables,lable,axis = 0)
    print(images.shape)
    print(lables.shape)
    
    train(model,images,lables)
    
    
    
    
    
Train = True
if __name__== "__main__":
   
    if Train:
        #x_train,y_train = load_data("./data/orl_faces")
        x_train,y_train,x_test,y_test = load_orldata("./data/orl_faces")
        
        print(x_train.shape)
        # print(len(x_train))
        # for i in x_train:
        #    image_add
        
        NB_CLASS = len(IMAGE_CLASSES)
                
        # print(NB_CLASS)
        # images_own,labels_own = Own_main("./data/lfw")
        
        # images = np.append(images_init,images_own,axis = 0)
        # print("images_shape:%s"%(len(images)))
        # lables = np.append(labels_init,labels_own,axis = 0)
        # print("lables_shape:%s"%(len(lables)))
        
        model = bulid_model()
        model = train(model,x_train,y_train)
        evaluate(model,x_test,y_test)
        
    else:
        predicts(load_models())
        #
        #Check(images,lables)
        
        
        
    
    