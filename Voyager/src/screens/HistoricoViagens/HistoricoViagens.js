import { Image, ScrollView, TouchableOpacity } from "react-native";
import { Container } from "../../components/container/style";
import { LogoViagens } from "../Viagens/style";
import {
  ContainerPostIts,
  PostItImage,
  PostIts,
  TextData,
  TextDestino,
  TitleViagensFuturas,
} from "../ViagensFuturas/style";

import { Back } from "../../components/Button/index";
import { MinhasViagens } from "../../components/Logo/Logo";

import { MaterialCommunityIcons } from "@expo/vector-icons";
import api from "../../service/Service";
import { useContext, useEffect, useState } from "react";
import { UserContext } from "../../contexts/MyContext";
import moment from "moment";

let viagensConcluidas = null;

export const HistoricoViagens = ({ navigation }) => {
  
  const { user } = useContext(UserContext)

  const BuscarHistoricoDeViagens = () => {
    api.get(`/Viagens/ListarViagensPassadas/${user.jti}`)
      .then(response => {
        viagensConcluidas = response.data;
        console.log(viagensConcluidas);
        console.log(response.data);
      })
      .catch(erro => {
        alert(erro)
      })
  }

  useEffect(() => {
    BuscarHistoricoDeViagens()
  }, [user])

  return (
    <Container>
      <Back navigation={navigation} screen={"Viagens"} />

      <MinhasViagens />

      <TitleViagensFuturas>
        Histórico de viagens{" "}
        <MaterialCommunityIcons name="airplane-clock" size={30} color="black" />
      </TitleViagensFuturas>

      <ScrollView style={{ width: "100%" }}>
        {viagensConcluidas !== null ?
          <ContainerPostIts>
            {[viagensConcluidas].map((viagem) => {
              return (
                <PostIts
                  key={viagem.id}
                  onPress={() =>
                    navigation.navigate("ViagemAtual", { type: "historico", idViagem: viagem.id })
                  }
                >
                  <PostItImage
                    source={{
                      uri: "https://github.com/AlbatrozPyt/VoyagerFrontEnd/blob/develop/Voyager/src/assets/images/post-it-2.png?raw=true"
                    }}
                  />

                  {/* <TextDestino>{viagem.endereco.cidadeDestino}</TextDestino> */}
                  <TextData>{moment(viagem.dataInicial).format("DD/MM")} - {moment(viagem.dataFinal).format("DD/MM")}</TextData>
                </PostIts>
              );
            })}
          </ContainerPostIts>
          : null}

      </ScrollView>
    </Container>
  );
};
