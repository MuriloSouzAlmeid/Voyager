import { Image, TouchableOpacity, View } from "react-native";
import {
  BoxOne,
  BoxThree,
  BoxTwo,
  CommentPost,
  ContainerBoxs,
  ContainerIcons,
  ContentPreviewFeed,
  ImageUserFeed,
  LikePost,
  PreviewFeed,
  TextPreviewFeed,
  ThumbnailFeed,
  TitlePreviewFeed,
} from "./style";
import { Shadow } from "react-native-shadow-2";
import { useState } from "react";

import { AntDesign } from "@expo/vector-icons";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import api from "../../service/Service";
import { ChatBotModal } from "../Modal";

export const PostFeed = ({ post, navigation, onPress, setComments, setPost }) => {
  const [like, setLike] = useState(false);
  

  async function GetComments(post) {
    await api.get(`/Comentarios/${post.id}`)
      .then((e) => {
        setComments(e.data)
        console.log(e.data)
      })
      .catch((e) => {
        console.log(e)
      })
  }

  return (
    <ContainerBoxs
      onPress={onPress}
    >
      <BoxOne>
        <BoxTwo>
          <BoxThree>
            {/* Imagem da postagem */}
            <ThumbnailFeed
              source={{
                uri: `https://github.com/AlbatrozPyt/VoyagerFrontEnd/blob/develop/Voyager/src/assets/images/FotoViagemFeed.png?raw=true`,
              }}
            />

            {/* Botões de comentar e gostei */}
            <ContainerIcons>
              <TouchableOpacity onPress={() => navigation.navigate("ChatBot")}>
                <MaterialCommunityIcons
                  name="comment-text-outline"
                  size={24}
                  color="black"
                />
              </TouchableOpacity>

              <TouchableOpacity
                onPress={() => {
                  !like ? setLike(true) : setLike(false);
                }}
              >
                {!like ? (
                  <AntDesign name="hearto" size={24} color="#ff2224" />
                ) : (
                  <AntDesign name="heart" size={24} color="#ff2224" />
                )}
              </TouchableOpacity>
            </ContainerIcons>

            {/* Prévia do conteudo */}
            <PreviewFeed>
              <ContentPreviewFeed>
                <TitlePreviewFeed>{post.titulo}</TitlePreviewFeed>

                <TextPreviewFeed>
                  ...
                </TextPreviewFeed>
              </ContentPreviewFeed>

              <Shadow
                startColor="#000"
                endColor="#000"
                distance={0}
                offset={[2, 2]}
                style={{ borderRadius: 8 }}
              >
                <ImageUserFeed
                  source={{
                    uri: "https://github.com/AlbatrozPyt/VoyagerFrontEnd/blob/develop/Voyager/src/assets/images/PedroFeed.png?raw=true",
                  }}
                />
              </Shadow>
            </PreviewFeed>
          </BoxThree>
        </BoxTwo>
      </BoxOne>

      
    </ContainerBoxs>
  );
};
